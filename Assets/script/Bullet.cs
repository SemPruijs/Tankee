using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particelExplotionEnemy;
    public GameObject particelExplotionObstacle;

    void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag)
        {
            case "Player":
                ExplodeEnemy();
                Destroy(gameObject);
                break;
            case "Obstacle": 
                Destroy(gameObject);
                ExplodeObstacle();
                break;
            case "speedPowerUp":
                Destroy(gameObject);
                break;
        }
    }

    void ExplodeEnemy() {
        GameObject ParticleSystem = Instantiate(particelExplotionEnemy, transform.position, Quaternion.identity);
        ParticleSystem.GetComponent<ParticleSystem>().Play();
        Destroy(ParticleSystem, 0.15f);
    }

    void ExplodeObstacle() {
        GameObject ParticleSystem = Instantiate(particelExplotionObstacle, transform.position, Quaternion.identity);
        ParticleSystem.GetComponent<ParticleSystem>().Play();
        Destroy(ParticleSystem, 0.15f);
    }
}
