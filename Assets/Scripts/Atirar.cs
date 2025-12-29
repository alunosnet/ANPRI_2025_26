using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject ModeloPrefab;
    public Transform PosicaoAtirar;
    public float Forca = 10f;
    public float IntervaloAtirar = 2f;
    public float IntervaloAtual;
    public float TempoVida = 10; //Tempo para a pedra desaparecer
    Personagem _personagem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IntervaloAtual = Time.time;
        if (ModeloPrefab == null)
            Debug.Log("Falta o modelo a atirar");
        if (PosicaoAtirar == null)
            Debug.Log("Falta a posição de atirar");
        _personagem = GetComponent<Personagem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_personagem.Estado == Personagem.NPCEstados.Morto) return;
        if (SistemaInput.instance.Atacar)
        {
            if (Time.time > IntervaloAtual)
            {
                _personagem.atacar= true;
                AtirarObjeto();
                IntervaloAtual = Time.time + IntervaloAtirar;
            }
        }
    }
    void AtirarObjeto()
    {
        //Criar uma instancia do prefab a atirar
        GameObject objeto = Instantiate(ModeloPrefab, 
                                        PosicaoAtirar.position, 
                                        Quaternion.identity);
        //Adicionar uma força
        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(PosicaoAtirar.forward * Forca, ForceMode.Impulse);
        }
        //fazer desaparecer ao fim do tempo de vida
        Destroy(objeto, TempoVida);
    }
}
