using UnityEngine;

public class Libertar : MonoBehaviour
{
    PersonagemNPC npc;
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

            Destroy(this.gameObject, 2);
        }
    }
}
