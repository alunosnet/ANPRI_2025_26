using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int contagem = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Executa a função AtualizarContagem de 2 em 2 segundos
        InvokeRepeating(nameof(AtualizarContagem), 0, 2);
        Invoke(nameof(MostrarContagem), 1);
    }
    void MostrarContagem()
    {

        SistemaMensagem.instance.MostraMensagem("Tens de salvar " + contagem + " crianças");
    }
    void AtualizarContagem()
    {
        contagem = GameObject.FindGameObjectsWithTag("Kid").Length;
        MudarNivel();
    }
    void MudarNivel()
    {
        if (contagem == 0)
        {
            Debug.Log("Mudar nivel");
            int n_cena = SceneManager.GetActiveScene().buildIndex;
            if (n_cena + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SistemaMensagem.instance.MostraMensagem("Parabéns salvaste todas as crianças.");
                Invoke(nameof(MenuPrincipal), 4);
            }
            else
            {
                SistemaMensagem.instance.MostraMensagem("Já não existem crianças presas neste nível. Parabéns.");
                Invoke(nameof(ProximoNivel), 4);
            }
        }
    }

    void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    void ProximoNivel()
    {
        GuardaNivel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void GuardaNivel()
    {
        int indiceNivel = SceneManager.GetActiveScene().buildIndex + 1;
        int indiceGravado = PlayerPrefs.GetInt("nivel", -1);
        if (indiceGravado < indiceNivel)
        {
            PlayerPrefs.SetInt("nivel", indiceNivel);
            PlayerPrefs.Save();
        }
    }
}
