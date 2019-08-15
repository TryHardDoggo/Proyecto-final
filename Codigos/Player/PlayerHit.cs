using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
    // Metodo para obtener los componentes necesarios, tales com la hitbox del jugador y asi llamar a la animacion de destruccion
    // Posteriormente se añadira mas animaciones tal como destruccion de enemigos etc.
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Comparamos los tag de cada uno de los objetos que tenemos en pantalla, asi determinamos si es enemigo u objeto destructible
        // actualmente no hay diferencia ya que ambos se destruyen en un hit del player.
        if (other.CompareTag("breakable")) {
            other.GetComponent<GrassDestruction>().Smash();
        }else if (other.CompareTag("Enemy")){
            other.GetComponent<Mobdestruction>().DestruyeEnemigo();
        }
    }
}
