using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float velocidad;

    private Transform player;
    private Vector3 target;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y);
    }

    void Update() {

        transform.position = Vector3.MoveTowards(transform.position, target, velocidad * Time.deltaTime);
        
        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestruyeProyectil();
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DestruyeProyectil();
        }
    }

    void DestruyeProyectil() {
        Destroy(gameObject);
    }

}
