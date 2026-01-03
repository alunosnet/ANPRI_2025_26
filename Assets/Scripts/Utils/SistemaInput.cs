using UnityEngine;
/// <summary>
/// Classe é responsável por ler o input do jogador
/// </summary>
public class SistemaInput : MonoBehaviour
{
    public InputSystem_Actions inputActions;
    //single
    public static SistemaInput instance;

    //guardar os dados de input do jogador
    public float EixoHorizontal;    //-1 0 1
    public float EixoVertical;
    public float DeltaRatoX;    //distancia do movimento do rato no eixo x
    public float DeltaRatoY;    //distancia do movimento do rato no eixo y
    public bool Correr;
    public bool Saltar;
    public bool Interact;
    public bool TeclaEsc;
    public bool Atacar;

    private void Awake()
    {
        //garantir que existe uma só instancia deste script
        if (instance !=null && instance != this)
        {
            Destroy(this);
            return;
        }
        //criar uma instancia
        instance = this;
        inputActions = new InputSystem_Actions();   //objeto para ler o input com o novo sistema de input
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void OnDestroy()
    {
        instance = null;
    }
    
    //ler movimento
    public void LerMovimento()
    {
        Vector2 movimento = inputActions.Player.Move.ReadValue<Vector2>();
        EixoHorizontal = movimento.x;
        EixoVertical = movimento.y;
    }
    //ler o movimento do rato
    public void LerRato()
    {
        Vector2 movimento = inputActions.Player.Look.ReadValue<Vector2>();
        DeltaRatoX = movimento.x;
        DeltaRatoY = movimento.y;
    }
    //ler o correr
    public void LerCorrer()
    {
        //ler o estado da tecla sem necessidade de saber quando carregou
        if (inputActions.Player.Sprint.ReadValue<float>() > 0)
            Correr = true;
        else
            Correr = false;
    }
    //ler o saltar
    public void LerSaltar()
    {
        //ler o estado da tecla (mas só executar se carregou na tecla na frame atual)
        Saltar = inputActions.Player.Jump.triggered;
    }
    //ler o interact
    public void LerInteract()
    {
        Interact = inputActions.Player.Interact.triggered;
    }
    //ler o Esc
    public void LerEsc()
    {
        TeclaEsc = inputActions.Player.Escape.triggered;
    }
    //ler o Atacar
    public void LerAtacar()
    {
        Atacar = inputActions.Player.Attack.triggered;
    }

    // Update is called once per frame
    void Update()
    {
        LerMovimento();
        LerRato();
        LerCorrer();
        LerSaltar();
        LerInteract();
        LerEsc();
        LerAtacar();
    }
}
