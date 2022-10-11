using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    private float playerSpeed = 3f;

    // Propiedad empleada para almacenar la rotacion de la camara en Y.
    private float cameraAxisX = 0f;
    [SerializeField] private float speedCamera = 10f;


    [SerializeField] Animator playerAnimator;

    private Vector3 playerDirection;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        //PRIMERA FORMA DE ANIMAR CON MOVIMIENTO: ANIMAR ANTES SE MOVER
        //Elegimos una animacion en función de la tecla que se empieza a presionar.
        bool forward = Input.GetKeyDown(KeyCode.W);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);
        
        //Es posible simplificar la notación del if si el bloque contiene una única línea.
        if (forward) playerAnimator.SetTrigger("FORWARD");
        if (back) playerAnimator.SetTrigger("BACK");
        if (left) playerAnimator.SetTrigger("LEFT");
        if (right) playerAnimator.SetTrigger("RIGHT");
        // Estamos en reposo si se deja de presionar alguna de las teclas de movimiento.
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            
            if (!IsAnimation("IDLE")) playerAnimator.SetTrigger("IDLE");
        }

        playerDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;

        //Nos movemos solo si hay una dirección diferente que vector zero.
        if (playerDirection != Vector3.zero) MovePlayer(playerDirection);
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }


    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedCamera * Time.deltaTime);
    }
}
