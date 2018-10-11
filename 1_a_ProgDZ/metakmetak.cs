using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class metakmetak : NetworkBehaviour
{
    // reference variable for bullet object
    public GameObject bulletPrefab;

    // reference variable for bullet travel
    public Transform bulletSpawn;

    // Called every frame
    void Update()
    {
        // if it isn't local player
        if (!isLocalPlayer)
        {
            return;
        }

        // get horizontal axis
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

        // same for vertical
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        // rotate on the X axis, left/right
        transform.Rotate(x, 0, 0);

        // move vertical axis
        transform.Translate(0, y, 0);

        // if the key is being hold
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // FIRE
            Fire();
        }
    }


    void Fire()
    {
        // Create the Bullet object from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}