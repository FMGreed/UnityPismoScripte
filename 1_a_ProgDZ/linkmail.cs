using UnityEngine;

public class linkmail : MonoBehaviour
{
	   
    //javni unos teksta za slanje maila
    public string mail;
	
	 //javna metoda za slanje maila na string mail
    public void OpenMail()
    {
        //otvaranje vanjske aplikacije za slanje maila
        Application.OpenURL("mailto:"+mail);
    }
}