using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    //variable de velocidad y un transform que captarael movimiento del player, asi poderlo rastrear
    public float velocidad;

    private Transform target;

    void Start() {

        //Decretamos que el target sera el GameOb con el tag "player y obtenemos sus componentes tal como posicion
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update() {

        // Por medio de if establecemos el rango en el qu deseamos que persiga al player o lo deje de seguir y tenga un espacio entre el jugador
        // asi no queda debajo del player
        if (Vector3.Distance(transform.position, target.position) <7 && (Vector3.Distance(transform.position, target.position) >.5)) {

            //Esta linea es dedicada a moverse a la posicion del jugador rastreado.
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
        }
    }
}
