using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour {


    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    void Awake()
    {
        // ovdje pomicemo i povecavamo/smanjujemo kocku
        transform.position = new Vector3(0, 0.25f, 0.75f);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // dodajemo isTrigger na nasu kocku
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;

        moveSpeed = 1.0f;

        // kreiramo kuglu za interakciju sa kockom
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.gameObject.transform.position = new Vector3(0, 0, 0);
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        sphere.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }
    // Kod ulaska u trigger ce nam se pojaviti poruka u log-u "entered"
    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");
        }
    }

    // stayCount dozvoljaca da se OnTriggerStay prikazuje manje cesto nego sto se zapravo odvija
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
                Debug.Log("staying");
                stayCount = stayCount - 0.25f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }
    // Kod izlaska iz triggera ce nam se pojaviti poruka u log-u "exit"
    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("exit");
        }
    }
}