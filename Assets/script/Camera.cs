using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public List<Transform> players;
    public Vector3 offset;
    public float Smoothness;

    public float minZoom;
    public float maxZoom;

    void LateUpdate() {
        if (players.Count == 0) {
            return;
        }

        move();
        zoom();
    }


    void zoom() {
        print(zoomDistance());
    }

    void move() {
        Vector3 centerpoint = CenterPointOfPlayers();
        Vector3 desiredPosition = centerpoint + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness); 

        transform.position = smoothPosition;
    }

    float zoomDistance() {
        //bounds expect 2 parameters: the center position, and the size.
        var bounds = new Bounds(players[0].position, Vector3.zero);

        for (int player = 0; player < players.Count; player++) {
            bounds.Encapsulate(players[player].position);
        }

        return bounds.size.x;
    }

    Vector3 CenterPointOfPlayers() {
        if (players.Count == 0) {
            return players[0].position;
        }


        //bounds expect 2 parameters: the center position, and the size.
        var bounds = new Bounds(players[0].position, Vector3.zero);
        for (int player = 0; player < players.Count; player++) {
            bounds.Encapsulate(players[player].position);
        }

        return bounds.center;
    }
}
