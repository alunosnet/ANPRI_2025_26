using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public TMP_Dropdown dp_resolucao;
    public TMP_Dropdown dp_qualidade;
    public Toggle tg_fullscreen;
    public RenderPipelineAsset[] qualityLevels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO: Ler as definições e aplicar na UI
    }
    //Toggle fullscreen
    public void tg_fullscreen_changed(bool state)
    {
        Screen.fullScreen = state;
        Debug.Log("Fullscreen changed");
    }
    //dropdown qualidade
    public void dp_qualidade_changed(int i)
    {
        QualitySettings.SetQualityLevel(i); //o nível de qualidade de acordo com as settings
        QualitySettings.renderPipeline = qualityLevels[i];
        Debug.Log("Quality changed");
    }
    //dropdown resolução
    public void dp_resolucao_changed(int i)
    {
        string resolucao = dp_resolucao.options[i].text;
        string[] escolha = resolucao.Split("x");    //800x600
        int largura = int.Parse(escolha[0]);
        int altura = int.Parse(escolha[1]);
        Screen.SetResolution(largura,altura,tg_fullscreen.isOn);
        Debug.Log("Resolucao changed");
    }
    public void Voltar_Click()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
