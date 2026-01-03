using UnityEngine;
/// <summary>
/// Script que implementa o mecanismo de vida de uma personagem
/// </summary>
public class Vida : MonoBehaviour
{
    public int max_vida = 100; // indica a vida com que a personagem começa o nível
    public int vida_atual = 0;
    public bool is_dead = false;
    AudioSource _audioSource;
    public AudioClip SomPerderVida;
    public AudioClip SomMorrer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        vida_atual = max_vida;
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.spatialBlend = 1;
        }
    }
    // Função que retira vida da personagem e deteta se morreu
    public void Perde_vida(int valor)
    {
        if (is_dead) return;
        vida_atual -= valor;
        if (vida_atual<=0)
        {
            vida_atual = 0;
            is_dead = true;
        }
        if (_audioSource == null) return;
        if (is_dead)
        {
            //_audioSource.clip = SomMorrer;
            if (SomMorrer!=null)
                _audioSource.PlayOneShot(SomMorrer);
        }
        else
        {
            if(SomPerderVida!=null)
                _audioSource.PlayOneShot(SomPerderVida);
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
