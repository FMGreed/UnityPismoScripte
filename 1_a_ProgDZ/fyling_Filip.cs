using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("Fly script added to: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10.0f;
        if (Input.GetButton("Fire1"))
            transform.position += transform.forward * Time.deltaTime * 40.0f;

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        // Ako je visina terena gdje se nalazimo veća od pozicije Y kretanja
        if (terrainHeightWhereWeAre > transform.position.y)
        {
            // Tada postavi nasu poziciju na sljedecu poziciju... Drugim rijecima, ne mozemo ici iznad dozvoljene Y granice "terrainHeightWhereWeAre"
            transform.position = new Vector3(transform.position.x,
                terrainHeightWhereWeAre,
                transform.position.z);
        }
    }
}

