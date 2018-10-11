using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skripta : MonoBehaviour
{
    public GameObject lopta;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update se pokreće prilikom svakog frame-a ili sličica u sekundi
	void Update () {
        // funkcija za stvaranje iste stvari u ovom slučaju lopte instantirat će loptu
        Instantiate(lopta);
    }
}
