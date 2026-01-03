using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string[] resolucoes;
    public RenderPipelineAsset[] qualityLevels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        AplicarSettings();
    }

    public void AplicarSettings()
    {
        bool fullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1 ? true : false;
        int qualidade = PlayerPrefs.GetInt("qualidade", 2);
        int resolucao = PlayerPrefs.GetInt("resolucao", 2);
        //aplica a setting fullscreen
        Screen.fullScreen = fullscreen;
        //aplica a setting resolucao
        string[] escolha = resolucoes[resolucao].Split("x");    //800x600
        int largura = int.Parse(escolha[0]);
        int altura = int.Parse(escolha[1]);
        Screen.SetResolution(largura, altura, fullscreen);
        //aplica a setting qualidade
        QualitySettings.SetQualityLevel(qualidade); //o nível de qualidade de acordo com as settings
        QualitySettings.renderPipeline = qualityLevels[qualidade];
    }

    public void Jogar()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void Continuar()
    {
        int indiceGravado = PlayerPrefs.GetInt("nivel", 2);
        SceneManager.LoadScene(indiceGravado);
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
