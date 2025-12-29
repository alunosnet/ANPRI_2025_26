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
    public string p_movimento = "movimento";
    public float movimento;
    public string p_saltar = "saltar";
    public bool saltar;
    public string p_atacar = "atacar";
    public bool atacar;
    public string p_morto = "morto";
    Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        vida = GetComponent<Vida>();
        _animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if (Estado == NPCEstados.Morto) return;
        //testa se a personagem está morta mas ainda não está no estado morto
        if (vida!=null && vida.is_dead)
        {
            Estado = NPCEstados.Morto;
            if (_animator != null)
            {
                //fazer a animação morrer
                _animator.SetBool(p_morto, true);
                Debug.Log("Anima morto");
            }
            return;
        }
        if (_animator != null)
        {
            _animator.SetFloat(p_movimento, movimento);
            if (saltar)
                _animator.SetTrigger(p_saltar);
            if (atacar)
                _animator.SetTrigger(p_atacar);
        }
        saltar = false;
        atacar = false;
    }
    
}
