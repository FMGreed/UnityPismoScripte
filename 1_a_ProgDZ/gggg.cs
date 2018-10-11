using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//za kretanja igraca po mapi 
public class gggg : MonoBehaviour {

 //input x i input z daju igracu da se moze kretat preko WASD tipki
        void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }
