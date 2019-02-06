using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class OpenData : MonoBehaviour
{
    //Nece vam raditi jer je ovo sad po mom pc-u
    public void ShowData()
    {
        System.Diagnostics.Process.Start("C:/Users/domin/Documents/GitHub/UnityPismoScripte/GD_Entertaiment/GD_Entertaiment/Assets/Resources/Data.txt");
    }
}
