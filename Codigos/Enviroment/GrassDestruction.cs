using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDestruction : MonoBehaviour {

    private Animator anim;          // variable determinada para la animacion 

    void Start() {
        anim = GetComponent<Animator>();            // Inicializar la y obtener los componentes del objeto y el animador
    }

    // Activacion del animador "smash" y llamada del metodo corutina para el termino de la animacion
    public void Smash() {
        anim.SetBool("smash", true);
        StartCoroutine(breakCO());
    }
    // metodo desactiva el estado del objeto para evitar que se pueda volver accionar la hitbox
    // asi la nanmacion queda en el ultimo frame y sigue existiendo el objeto en el escenario
    IEnumerator breakCO() {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
