using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
// skripta koja koristi javnu klasu pokretanje novcica
public class Pokretanje_novcica : MonoBehaviour {
   // javna brzina novcica je 10f
    public float moveSpeed = 10f;
    private void FixedUpdate()
    {
        // pomicanje po horizontalnoj osi
        float moveX = Input.GetAxis("Horizontal");
        // pomicanje po vertikalnoj osi
        float moveZ = Input.GetAxis("Vertical");

        // postupak pomicanja lika
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        GetComponent<Rigidbody>().velocity = movement * moveSpeed * Time.deltaTime;
    }
}
