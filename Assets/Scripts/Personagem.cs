using UnityEngine;
/// <summary>
/// Script base de todas as personagens (player, npcs, etc)
/// Implementa o script Vida e as animações
/// </summary>
public class Personagem : MonoBehaviour
{
    //Estados possíveis para as personagens
    public enum NPCEstados { Idle = 0, Patrulha = 1, Atacar = 2, Morto =3, Fugir = 4 }
    public Vida vida;
    public NPCEstados Estado;
    // Variáveis para controlar as animações
    public int movimento;
    public bool saltar;
    public bool atacar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        vida = GetComponent<Vida>();
    }

    
}
