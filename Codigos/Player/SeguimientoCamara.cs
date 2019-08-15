using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour {
    // Delaracion de variables 
    public Transform target; // El seguimiento de la camara
    public float smoothing; // Valor flotante ya que es un valor mas preciso, ya que la camara requiere ser suave y precisa
    public Vector2 maxPosition;         // Delimitantes de la camara, evitando que salga de los planos deseados, maximo y minimo
    public Vector2 minPosition;

    void Start() {
        
    }
    // Se usara "Late update" ya que Update es actualizado cada uno de los frames y en orden logico es el ultimo
    void LateUpdate() {
        if (transform.position != target.position) {
            // Funcion para arreglar la posicion de la camara en el eje Z, ya que la camara pasa por debajo del plano requerido
            // de manera que se puede instanciar la transformacion de la camara a esta y no usar el target directamente
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            // Calculo para fijar camara en esquinas    
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            // Seguimiento instanciado al previo
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
