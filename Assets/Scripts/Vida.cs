using UnityEngine;
/// <summary>
/// Script que implementa o mecanismo de vida de uma personagem
/// </summary>
public class Vida : MonoBehaviour
{
    public int max_vida = 100; // indica a vida com que a personagem começa o nível
    public int vida_atual = 0;
    public bool is_dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida_atual = max_vida;
    }
    // Função que retira vida da personagem e deteta se morreu
    public void Perde_vida(int valor)
    {
        vida_atual -= valor;
        if (vida_atual<=0)
        {
            vida_atual = 0;
            is_dead = true;
        }
    }
    //Função que adiciona vida à personagem respeitando o max_vida
    public void Ganha_vida(int valor)
    {
        vida_atual += valor;
        if (vida_atual> max_vida)
            vida_atual= max_vida;
    }
}
