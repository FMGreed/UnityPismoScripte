using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSphere : MonoBehaviour
{
    public GameObject sphere;
    //Collider col;

    void Start()
    {
        //col = GetComponent<Collider>();
        sphere.SetActive(false);
    }
    void OnMouseDown()
    {
        sphere.SetActive(true);
    }
}
