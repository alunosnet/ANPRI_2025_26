using UnityEngine;
using UnityEngine.AI;

public class PersonagemNPC : Personagem
{
    //Indica se o npc ataca o player
    public bool Inimigo = true;
    //pontos do estado patrulha
    public Transform[] Pontos;
    public int ProximoPonto = 0;
    public float Velocidade = 3;
    public float DistanciaMinima = 1;
    public float DistanciaAtaca = 1;
    public int ValorTiraVida = 10;
    public float DistanciaVisao = 50;
    public float AnguloVisao = 90;
    public Transform Olhos;
    public GameObject Player;
    public float TempoEspera = 5;
    public float TempoAEspera = 0;
    public float IntervaloAtacar = 5;
    public float IntervaloAtual = 0;
    NavMeshAgent _agente;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();   //Executa o código da classe base
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Debug.Log("Não encontrei o player");
        }
        _agente = GetComponent<NavMeshAgent>();
        TempoAEspera = TempoEspera;
    }
    void Estado_Morto()
    {
        _agente.isStopped= true;
        _agente.speed = 0;
        _agente.velocity = Vector3.zero;
        Estado = NPCEstados.Morto;
        movimento = 0;
    }
    void Estado_Idle()
    {
        _agente.isStopped = true;
        _agente.speed = 0;
        _agente.velocity = Vector3.zero;
        Estado = NPCEstados.Idle;
        movimento = 0;
    }
    void Estado_Patrulha()
    {
        //Verificar se existem pontos para patrulhar
        if (Pontos.Length == 0)
        {
            Estado = NPCEstados.Idle;
            return;
        }
        if (_agente.isOnNavMesh)
            _agente.isStopped = false;
        _agente.speed = Velocidade;
        //verificar se pode passar ao ponto seguinte
        if (Vector3.Distance(transform.position, 
                            Pontos[ProximoPonto].position)<DistanciaMinima)
        {
            //se só tem um ponto passa para o estado idle
            if (Pontos.Length == 1)
            {
                Estado_Idle();
                return;
            }
            //Passar para o próximo ponto
            ProximoPonto++;
            if (ProximoPonto >= Pontos.Length)
                ProximoPonto = 0;
        }
        //Definir o ponto para onde se move
        _agente.SetDestination(Pontos[ProximoPonto].position);
        //definir a animação de andar
        movimento = 1;
    }
    void Estado_Atacar()
    {
        _agente.speed = Velocidade * 1.5f;
        //rodar para o player ignorando o y do player
        Vector3 OlharPara = new Vector3(Player.transform.position.x,
                                        transform.position.y,
                                        Player.transform.position.z);
        transform.LookAt(OlharPara);
        //atacar?
        if (Vector3.Distance(transform.position,
                            Player.transform.position)<DistanciaAtaca)
        {
            //Atacar
            _agente.isStopped = true;
            _agente.velocity = Vector3.zero;
            if (Time.time > IntervaloAtual)
            {
                IntervaloAtual = Time.time + IntervaloAtacar;
                Player.GetComponent<Vida>().Perde_vida(ValorTiraVida);
                atacar = true;
            }
        }
        else
        {
            _agente.isStopped = false;
            _agente.SetDestination(Player.transform.position);
        }
    }
    bool VePlayer()
    {
        if (Vector3.Distance(transform.position,
                            Player.transform.position)>DistanciaVisao)
        {
            return false;
        }
        return Utils.CanYouSeeThis(Olhos, Player.transform, "Player",
                                    AnguloVisao, DistanciaVisao);
    }
    // Update is called once per frame
    void Update()
    {
        if (_agente==null)
        {
            Debug.Log("Falta o NavMeshAgent!");
            return;
        }
        if (vida!=null && vida.is_dead)
        {
            Estado_Morto();
            return;
        }
        //TODO: base.Update();
        switch (Estado)
        {
            case NPCEstados.Idle:
                Estado_Idle();
                if (Inimigo && VePlayer())
                    Estado = NPCEstados.Atacar;
                break;
            case NPCEstados.Patrulha:
                Estado_Patrulha();
                if (Inimigo && VePlayer())
                    Estado = NPCEstados.Atacar;
                break;
            case NPCEstados.Atacar:
                if (Inimigo == false)
                {
                    Estado = NPCEstados.Patrulha;
                    return;
                }
                if (VePlayer())
                {
                    Estado_Atacar();
                    TempoAEspera = TempoEspera;
                }
                else
                {
                    TempoAEspera -= Time.deltaTime;
                    if (TempoAEspera < 0)
                    {
                        Estado = NPCEstados.Patrulha;
                        TempoAEspera = TempoEspera;
                    }
                }
                break;
        }
    }
}
