using UnityEngine;
/// <summary>
/// Script que deteta a colisão com uma personagem e retira vida dessa personagem
/// </summary>
public class TiraVida : MonoBehaviour
{
    public int ValorPerdeVida = 10; //valor retirado da vida da personagem
    public float IntervaloPerdeVida = 1;    //intervalo de tempo em segundos para perder vida
    public string IgnoraTags = "";  //se o objeto tiver uma determinada tag não perde vida
    float ProximoIntervalo = 0;

    //Colisão iniciada
    private void OnCollisionEnter(Collision collision)
    {
        ProcessaColisao(collision.gameObject);
    }
    
    //Objetos em contacto
    private void OnCollisionStay(Collision collision)
    {
        ProcessaColisao(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        ProcessaColisao(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        ProcessaColisao(other.gameObject);
    }
    void ProcessaColisao(GameObject quemColidiu)
    {
        //verificar se já passou o intervalo de tempo para perder vida
        if (Time.time < ProximoIntervalo)
            return;
        // verificar se é uma tag a ignorar
        if (IgnoraTags.Contains(quemColidiu.tag))
            return;
        //Referencia para o componente vida do game object
        var vida = quemColidiu.GetComponent<Vida>();
        //Se tiver vida entao perde
        if (vida != null )
        {
            vida.Perde_vida(ValorPerdeVida);
            ProximoIntervalo = Time.time + IntervaloPerdeVida;
        }
    }
}
