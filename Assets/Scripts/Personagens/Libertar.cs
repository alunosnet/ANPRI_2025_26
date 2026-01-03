using UnityEngine;

public class Libertar : MonoBehaviour
{
    PersonagemNPC npc;
    public GameObject efeito;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npc = GetComponent<PersonagemNPC>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            npc.Estado = Personagem.NPCEstados.Patrulha;
        }

        if (other.tag=="Objetivo")
        {
            if (efeito != null)
            {
                var efeito_particulas = Instantiate(efeito, transform.position, Quaternion.identity);
                Destroy(efeito_particulas, 2);
            }
            Destroy(this.gameObject, 1);
        }
    }
}
