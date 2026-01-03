using TMPro;
using UnityEngine;
/// <summary>
/// Singleton para mostrar mensagens ao jogador
/// </summary>
public class SistemaMensagem : MonoBehaviour
{
    public static SistemaMensagem instance;
    public TextMeshProUGUI textoMensagem;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        textoMensagem = GetComponent<TextMeshProUGUI>();
        EscondeMensagem();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
 
    }

    public void MostraMensagem(string texto,float duracao=4)
    {
        textoMensagem.text = texto;
        textoMensagem.enabled = true;
        Invoke(nameof(EscondeMensagem), duracao);
    }
    void EscondeMensagem()
    {
        textoMensagem.text = "";
        textoMensagem.enabled = false;
    }
}
