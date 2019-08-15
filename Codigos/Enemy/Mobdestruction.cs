using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobdestruction : MonoBehaviour {

    // void publico para poderlo llamar desde otro script
    // Desactivar el objeto dentro del escenario.
    public void DestruyeEnemigo() {
        Destroy(gameObject);
        this.gameObject.SetActive(false);
    }
}
