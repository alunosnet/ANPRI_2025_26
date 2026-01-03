using UnityEngine;

public class TocarSons : MonoBehaviour
{
    public AudioClip[] passos;
    public int ProximoSom = 0;
    AudioSource _audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();    
    }
    //Função executada a partir do evento das animações de andar e correr
    public void TocarSomPassos()
    {
        if (_audioSource == null || passos.Length == 0) return;
        _audioSource.PlayOneShot(passos[ProximoSom]);
        ProximoSom++;
        if (ProximoSom >= passos.Length)
            ProximoSom = 0;
    }
}
