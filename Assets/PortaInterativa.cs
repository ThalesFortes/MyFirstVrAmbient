using UnityEngine;
using UnityEngine.InputSystem;


public class PortaInterativa : MonoBehaviour
{
    [Header("Configurações da Porta")]
    public float anguloAberta = 90f;   
    public float velocidade = 2f;       
    public float distanciaInteracao = 3f; 

    [Header("Referência do Jogador")]
    public Transform jogador;

    private bool estaAberta = false;
    private bool estaMovendo = false;
    private Quaternion rotacaoFechada;
    private Quaternion rotacaoAberta;

    void Start()
    {
        rotacaoFechada = transform.rotation;
        rotacaoAberta = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y + anguloAberta,
            transform.eulerAngles.z
        );
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia <= distanciaInteracao &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            estaAberta = !estaAberta; 
        }

        Quaternion alvo = estaAberta ? rotacaoAberta : rotacaoFechada;
        transform.rotation = Quaternion.Lerp(
            transform.rotation, alvo, velocidade * Time.deltaTime
        );
    }
}