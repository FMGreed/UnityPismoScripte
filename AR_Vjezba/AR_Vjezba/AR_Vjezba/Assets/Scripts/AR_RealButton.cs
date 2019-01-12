using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AR_RealButton : MonoBehaviour
{
    public GameObject vtButton;
    public GameObject first;

    void Start()
    {
        vtButton.GetComponent<VirtualButtonBehaviour>();
    }

    public void OnButtonEnter(VirtualButtonBehaviour vb)
    {
        first.SetActive(false);
    }
}
