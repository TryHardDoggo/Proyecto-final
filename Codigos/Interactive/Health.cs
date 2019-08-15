using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


    //Variables publicas para uso dela vida
    public int vida;
    public int numCora;
    
    //Arreglo que contendra las imagenes de los corazones desplegados en pantalla
    //Corazon lleno y vacio.
    public Image[] cora;
    public Sprite coraLleno;
    public Sprite coraVac;

    void Update() {


        // Delimitar el maximo de Corazones que puedes poseer
        if (vida > numCora) {
            vida = numCora;
        }

        //Delimitacion con ciclo for del numero de corazones disponibles a obtener 
        for (int i = 0; i < cora.Length; i++) {

            //Comparacion para determinar si el sprite sera el corazon lleno o el corazon vacio.
            if(i < vida) {
                cora[i].sprite = coraLleno;
            } else {
                cora[i].sprite = coraVac;
            }

            // Activacion y desactivacion del sprite 
            if (i < numCora) {
                cora[i].enabled = true;
            }else {
                cora[i].enabled = false;
            }
        }
    }
}
