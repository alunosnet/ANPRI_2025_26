using TMPro;
using UnityEngine;

public class VidaUI : MonoBehaviour
{
    public TextMeshProUGUI txtVida;
    public Vida vidaPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtVida=GetComponent<TextMeshProUGUI>();
        vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (txtVida != null && vidaPlayer != null)
        {
            txtVida.text = vidaPlayer.vida_atual.ToString();
        }
    }
}
