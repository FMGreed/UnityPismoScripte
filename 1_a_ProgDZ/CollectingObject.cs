using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//klasa pod nazivom CollectingObject koja sluzi prikupljanju itema
public class CollectingObject : MonoBehaviour
{
    //u Unityju je potrebno staviti objekt koji zelimo pokupiti da ima collider i Is Trigger
    void OnTriggerEnter(Collider other)
    {
        //u Unityju objektu kojeg prikupljamo trebamo staviti tag PickUp (kreirati novi tag)
        if (other.gameObject.CompareTag("PickUp"))
        {
            //kada player dotakne collider od PickUp objekta, objekt ce postati neaktivan, odnosno vizualno ce nestati iz scene (biti pokupljen)
            other.gameObject.SetActive(false);
        }
    }
}