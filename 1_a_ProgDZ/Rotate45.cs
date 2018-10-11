using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate45 : MonoBehaviour {

    public float StupanjRotacije = 45f;

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.right * StupanjRotacije);
            Debug.Log("Stisnili ste desnu strelicu.");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.Rotate(Vector3.left * StupanjRotacije);
            Debug.Log("Stisnili ste lijevu strelicu.");
        }
        else if(!Input.GetKeyDown(KeyCode.RightArrow) || !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("Pritisnuli ste: " + Input.inputString);
            }
        }
    }
}
