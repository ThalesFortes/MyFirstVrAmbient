using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentacaoPC : MonoBehaviour
{
    public float velocidade = 3f;
    public float velocidadeRotacao = 80f;
    public float sensibilidadeMouse = 2f;

    private CharacterController controller;
    private Transform cameraPrincipal;
    private float rotacaoVertical = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraPrincipal = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void Update()
    {
        var teclado = Keyboard.current;
        var mouse = Mouse.current;
        if (teclado == null || mouse == null) return;

        // Movimento WASD
        float mover = 0f;
        float rotacionar = 0f;

        if (teclado.wKey.isPressed) mover = 1f;
        if (teclado.sKey.isPressed) mover = -1f;
        if (teclado.aKey.isPressed) rotacionar = -1f;
        if (teclado.dKey.isPressed) rotacionar = 1f;

        float mouseX = mouse.delta.x.ReadValue() * sensibilidadeMouse;
        float mouseY = mouse.delta.y.ReadValue() * sensibilidadeMouse;

        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -80f, 80f); 

        cameraPrincipal.localRotation = Quaternion.Euler(rotacaoVertical, 0f, 0f);
        transform.Rotate(0, mouseX + rotacionar * velocidadeRotacao * Time.deltaTime, 0);

        Vector3 movimento = transform.forward * mover * velocidade;
        movimento.y -= 9.8f;
        controller.Move(movimento * Time.deltaTime);

        if (teclado.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}