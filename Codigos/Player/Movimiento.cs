using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declaracion de un enumerador con los estados dentro del jugador,IDLE no es un estado si no una booleana la cual al ser falso, regresa a un sprite inactivo
public enum PlayerState{
    walk,
    attack
}

public class Movimiento : MonoBehaviour {
    // Declaracion de Variables
    public PlayerState currentState;                // Variable que define el estado en el que se encuentra el objeto
    public float maxSpeed = 0;                      // Esta variable puede pasar a HidenInspector, sin embargo para motivos de prueba la dejo fuera
    private Rigidbody2D playerRigBody;
    private Vector3 translation;

    private Animator anima;
    // Inicializacion de animacion y Player como cuepro rigido 2D
    void Start() {
        anima = GetComponent<Animator>();
        playerRigBody = GetComponent<Rigidbody2D>();
    }
    // Movimiento en cualquier direccion con las crucetas del ordenador, sin embargo aqui no esta establecida la velocidad
    // Tambien es llamado un estado de caminata y un estado de ataque el cual cita a los metodo()
    void Update() {
        translation = Vector3.zero;
        translation.x = Input.GetAxis("Horizontal");
        translation.y = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack) {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk) {
            UpdateAnimaionAndMove();
        }
    }
    // Metodo dedicado al ataque 
    // Booleanas para activar el estado de ataque o desactivarlo
    private IEnumerator AttackCo() {
        anima.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anima.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);           // Tiempo para que la animacion no sea repetida cada uno de los frames
        currentState = PlayerState.walk;                // tetorno al estado de caminata una vez que haya terminado la animacion de ataque
    }

    // Actualizacion de la animacion por fames especificaente de la animacion caminata
    // cuenta con un booleano para cambiar de estado activo a inactivo y regresar al IDLE
    void UpdateAnimaionAndMove() {
        if (translation != Vector3.zero) {
            TranslationCharacter();
            anima.SetFloat("TransX", translation.x);
            anima.SetFloat("TransY", translation.y);
            anima.SetBool("Translate", true);
        } else {
            anima.SetBool("Translate", false);
        }
    }
    //Velocidad del Player linkeada a la variable modificable dentro del inspector
    void TranslationCharacter() {
        playerRigBody.MovePosition(
            transform.position + translation * maxSpeed * Time.deltaTime);
    }
}
