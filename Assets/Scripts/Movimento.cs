using UnityEngine;
/// <summary>
/// Classe para mover o player no mundo
/// </summary>
public class Movimento : MonoBehaviour
{
    public float VelocidadeAndar = 3;
    public float VelocidadeRodar = 30;
    public float VelocidadeSalto = -2; //deve ser negativo

    public float _inputRodar;
    public float _inputAndar;
    public bool _inputSaltar;
    public bool _isGrounded;
    Vector3 _velocidade;

    CharacterController controller; //referencia para o componente CharacterController

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
            Debug.Log("Falta o character controller no player");
    }

    // Update is called once per frame
    void Update()
    {
        //rotação
        _inputRodar = SistemaInput.instance.DeltaRatoX;
        //transform.up - indica o eixo de rotação
        //Time.deltaTime - indica o tempo que a ultima frame demorou a ser desenha
        transform.Rotate(transform.up * _inputRodar * VelocidadeRodar * Time.deltaTime);
        //movimento
        _inputAndar = SistemaInput.instance.EixoVertical;
        //transform.forward - indica para onde o player "esta virado"
        Vector3 vector3 = transform.forward * _inputAndar * VelocidadeAndar * Time.deltaTime;
        //correr
        if (SistemaInput.instance.Correr==false)
            controller.Move(vector3);
        else
            controller.Move(vector3*1.5f);
        //saltar e gravidade
        if (_isGrounded && SistemaInput.instance.Saltar)
        {
            _velocidade.y = Mathf.Sqrt(VelocidadeSalto * Physics.gravity.y);
        }
        else
        {
            //aplicar gravidade
            _velocidade += Physics.gravity * Time.deltaTime;
        }
        //aplicar salto ou gravidade
        controller.Move(_velocidade * Time.deltaTime);
        //saber se o player tem os pés no chão
        _isGrounded = controller.isGrounded;
    }
}
