using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaneModelOnButton : MonoBehaviour
{
    public GameObject FirstObject; //Prvi objekt
    public GameObject SecondObject; // Drugi objekt

    void Start()
    {
        FirstObject.SetActive(true);
        SecondObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (FirstObject.activeInHierarchy == true)
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