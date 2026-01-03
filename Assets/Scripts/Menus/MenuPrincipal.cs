using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void Continuar()
    {
        //TODO: carregar o último nível jogado
    }
    public void Configuracoes()
    {
        SceneManager.LoadScene("configuracoes");
    }
    public void Sair()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
