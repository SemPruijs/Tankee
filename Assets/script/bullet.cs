using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject particelExplotion;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Explode();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Obstacle") {
            Destroy(gameObject);
        }
    }

    void Explode() {
        GameObject ParticleSystem = Instantiate(particelExplotion, transform.position, Quaternion.identity);
        ParticleSystem.GetComponent<ParticleSystem>().Play();
        Destroy(particelExplotion, 0.15f);
    }
}
