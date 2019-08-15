using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uso de una maquina de estados para comportamientos de enemigos mas complejos
// Que realizan mas de una accion, tal como un jefe, o un mob con distintos patrones de comportamiento
public enum EnemyIA {
    patrulla,
    perseguir,
    atacar
}

public class MobNodosAI : MonoBehaviour {

    //Variables modificables en el inspectos para objecto de practicidad
    public float velocidad;
    public Transform gema;
    public Transform[] nodo;

    public Transform matriz;
    public int indiceMatriz;
    public Transform player;
    public EnemyIA ActualState = new EnemyIA();

    void Start() {
        // declaracion del estado en el que inicia el enemigo al entrar en el escenario
        ActualState = EnemyIA.patrulla;
        matriz = nodo[1]; // la matriz que contiene los nodos los cuales el enemigo estara cruzando
        gema.position = matriz.position; // establecemos que iniciara en la posicion de la matriz al ejecutar el programa
        velocidad = velocidad * Time.deltaTime; // la velocidad de la que sera modifibale en el inspector
        indiceMatriz = 0;   // el inidce por el que empezara a contar los nodos 
    }

    void Update() {
        // Establecemos la direccion que se movera dependiendo el acomodo de los nodos, seguira un orden en lista
        Vector3 dir = matriz.position - gema.position;       
        float distancia = Vector3.Distance(gema.position, matriz.position);     // deteccion de la distancia entre el objeto y el siguiente nodo
        float distanciaPlayer = Vector3.Distance(gema.position, player.position);       // deteccion de distancia entre objeto yel jugador

        // traslacion de objeto a la posicion del nodo
        gema.Translate(dir.normalized * velocidad, Space.World);

        // iniciamos el primero comprtamiento al comparar el estado del objeto
        if (ActualState == EnemyIA.patrulla) {

            matriz = nodo[indiceMatriz];

            if (distancia <= 0.5f) {
                if (indiceMatriz >= nodo.Length - 1) {
                    indiceMatriz = 0;
                    matriz = nodo[indiceMatriz];
                }

                indiceMatriz++;
                matriz = nodo[indiceMatriz];
            }
        }
        // Cambio de estado al reconocer que la distacia es menor de lo estipulado, entre el objeto y el jugador
        if (distanciaPlayer <= 2) {
            ActualState = EnemyIA.perseguir;

            // Cambia entre la matriz al jugador para que sea perseguido
            if (ActualState == EnemyIA.perseguir) {
                matriz = player;
            }
        } else if (distanciaPlayer >= 2) { // If para regresar a su estado patrulla, asi si el jugador esta alejado, el objeto seguira su trayectoria
            ActualState = EnemyIA.patrulla; // y si el jugador se aleja post acercarse al mob, este regresara a su estado patrulla
            if (ActualState == EnemyIA.patrulla) {
            }
        }
    }
}
