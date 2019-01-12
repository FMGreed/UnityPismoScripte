using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // Jedino kada imamo "Standard assets" u projektu

public class AR_Cross_Controller : MonoBehaviour
{
    Rigidbody rb;
    float X;
    float Z;
    Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        X = CrossPlatformInputManager.GetAxis("Horizontal"); //X os kada pomićemo gumb vodoravno / horizontali
        Z = CrossPlatformInputManager.GetAxis("Vertical");// Z os kada pomićemo gumb okomito / vertikalno

        move = new Vector3(X, 0, Z); // Dodjeljujemo smjer kretnje

        rb.velocity = move * 0.5f; //konstantna brzina

        if(X != 0 || Z != 0) //rotacija samo kada je lik u pokretu
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(X, Z) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}
