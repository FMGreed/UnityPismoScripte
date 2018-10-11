using UnityEngine;
using System.Collections;

    //deklariranje funkcije CameraSwitch za prebacivanje kamere
public class CameraSwitch : MonoBehaviour
{
    //Varijabla cam1 za prvu kameru
    public Camera cam1;
    //Varijabla cam2 za drugu kameru
    public Camera cam2;

    //Nakon pokretanja inicijaliziramo cam2 kameru kao aktivnu
    //public void Start()
    //{
    //    cam1.enabled = false;
    //    cam2.enabled = true;
    //}

    //na pritisak tipke C kamera se mijenja na drugu
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }

    }
}