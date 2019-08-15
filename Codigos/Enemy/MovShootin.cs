using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maquina de estados para atacar y estar en IDLE
public enum EnemySho {
    IDLE,
    attack
}

public class MovShootin : MonoBehaviour {

    //varables publicas para uso de ellas en todo el script
    public float velocidad;
    public float alto;
    public float cercania;
    public float coldown;   // realentizacino del disparo para no saturar la maquina.
    public float inicio;

    public GameObject shot;     // Objeto que se instanciara y sera disparado como proyectil
    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() { // Generar un patron para que el enemigo se retire y caze al jugador, disparando.
        if (Vector3.Distance(transform.position, player.position) > 10) {
            transform.position = this.transform.position;
        }else if (Vector3.Distance(transform.position, player.position) < 10) {
            if (Vector3.Distance(transform.position, player.position) < cercania) {
                transform.position = Vector3.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
            } else if (Vector3.Distance(transform.position, player.position) > cercania) {
                transform.position = Vector3.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
            } else if (Vector3.Distance(transform.position, player.position) < alto && Vector3.Distance(transform.position, player.position) > cercania) {
                transform.position = this.transform.position;
            }
        }
        
        // Usamos una identidad cuaternionpara que no dispare cada uno de los frames.
        if (coldown <= 0) {
            Instantiate(shot, transform.position, Quaternion.identity);
            coldown = inicio;
        } else {
            coldown -= Time.deltaTime;
        }
        
    }
}
