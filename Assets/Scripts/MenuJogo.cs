using UnityEngine;

public class MenuJogo : MonoBehaviour
{
    Vida _vidaPlayer;
    //Referencia para o painel do menu de jogo
    public GameObject P_MenuJogo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Esconder o cursor do rato
        Cursor.lockState = CursorLockMode.Locked;
        _vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        //esconder o painel do menu de jogo
        P_MenuJogo.SetActive(false);
    }
    public void Pausa()
    {
        //mostrar o menu
        P_MenuJogo.SetActive(true);
        //Parar o jogo
        Time.timeScale = 0;
        //Mostrar o cursor do rato
        Cursor.lockState = CursorLockMode.None;
    }
    public void Continuar()
    {
        P_MenuJogo.SetActive(false);    //esconder o menu
        Time.timeScale = 1; //Continuar o jogo
        Cursor.lockState = CursorLockMode.Locked; //esconder o rato
    }
    //TODO: Sair -> carregar o menu principal
    public void Sair()
    {
        Debug.Log("Sair");
    }
    //TODO: Materializar o nível jogado
    // Update is called once per frame
    void Update()
    {
        if (SistemaInput.instance.TeclaEsc)
        {
            if (Time.timeScale == 0)
                Continuar();
            else
                Pausa();
        }
        if (_vidaPlayer.is_dead)
        {
            SistemaMensagem.instance.MostraMensagem("Game Over");
            Invoke(nameof(Sair), 5);
        }
    }
}
