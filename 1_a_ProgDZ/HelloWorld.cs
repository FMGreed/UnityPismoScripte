using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour

{

	// ova Start funkcija (koje sad nema) se pokreće samo jedanput prilikom pokretanja same igre ili skripte
	void Start ()
    {
        
	}
	
	// Update se pokreće prilikom svakog frame-a, frame ili fps znaći sličica u sekundi
	void Update ()
    {
        // print je funkcija koja ispisuje niz znakova u ovom slučaju Hello world!
        print("Hello world!");
    }
}
