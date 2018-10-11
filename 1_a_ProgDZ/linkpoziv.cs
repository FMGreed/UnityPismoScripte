using UnityEngine;

public class linkpoziv : MonoBehaviour
{
	//javni unos teksta za poziv
    public string tele;
	
	 //javna metoda za poziv na tele broj
    public void OpenTele()
    {
        //otvaranje vanjske aplikacije za poziv
        Application.OpenURL("tel://"+tele);
    }
}