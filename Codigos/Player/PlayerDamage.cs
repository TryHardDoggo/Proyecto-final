using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    Health playerHealth;

    private void Start() {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Enemy") {

            Debug.Log("Hola");
        }
    }
}