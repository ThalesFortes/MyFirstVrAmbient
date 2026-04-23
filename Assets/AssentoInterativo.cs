using UnityEngine;
using UnityEngine.InputSystem;

public class AssentoInterativo : MonoBehaviour
{
    [Header("Configurações do Assento")]
    public float distanciaInteracao = 2f;
    public Transform pontoDeSentado; 

    [Header("Referência do Jogador")]
    public Transform jogador;
    public CharacterController characterController;

    // controle interno
    private bool estaSentado = false;
    private Vector3 posicaoOriginal;

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if ((distancia <= distanciaInteracao || estaSentado) &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!estaSentado)
                Sentar();
            else
                Levantar();
        }
    }

    void Sentar()
    {
   
        posicaoOriginal = jogador.position;

        characterController.enabled = false;

        jogador.position = pontoDeSentado.position;
        jogador.rotation = pontoDeSentado.rotation;

        characterController.enabled = true;

        estaSentado = true;
        Debug.Log("Sentou em: " + gameObject.name);
    }

    void Levantar()
    {
        characterController.enabled = false;

        jogador.position = posicaoOriginal;

        characterController.enabled = true;

        estaSentado = false;
        Debug.Log("Levantou de: " + gameObject.name);
    }
}