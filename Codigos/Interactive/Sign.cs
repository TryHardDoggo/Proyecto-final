using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   // Uso del UI para poder utilizar texto entre otros elementos

public class Sign : MonoBehaviour {
    // Declaracion de variables
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;

    void Start() {
        
    }
    //Chequeo de la hitbox con el jugador, metodo if con doble condicional 
    // estableciendo acciones a un area determinada
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && dialogActive) {
            if (dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            } else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    // Metodo para al detectar la hitbox del jugador, pase de desactivado a activado
    // Asi poder accionar la textbox en contacto de las hitbox
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            dialogActive = true;
        }
    }
    // En orden gerarquico, este metodo esta dedicado para regresar el estado del texto a falso
    // y asi desaparezca 
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            dialogActive = false;
            dialogBox.SetActive(false);
        }
    }
}
