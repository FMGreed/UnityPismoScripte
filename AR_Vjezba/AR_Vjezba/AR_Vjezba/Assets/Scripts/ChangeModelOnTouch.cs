using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelOnTouch : MonoBehaviour
{
    public GameObject FirstObject; //Prvi objekt
    public GameObject SecondObject; // Drugi objekt
    Collider colider; //Kolajder na glavnom (Parentu/Roditelju) game objecta

    void Start() //Određujemo koji je prvi objekt aktivan i pronalazimo Collider
    {
        FirstObject.SetActive(true);
        SecondObject.SetActive(false);
        colider = GetComponent<Collider>();
    }

    void OnMouseDown() //Metoda kada kliknemo mišem ili dodirnemo prstom ekran (ako je na touch)
    {
        if(FirstObject.activeInHierarchy == true)
        {
            FirstObject.SetActive(false);
            SecondObject.SetActive(true);
        }
        else
        {
            FirstObject.SetActive(true);
            SecondObject.SetActive(false);
        }
    }
}