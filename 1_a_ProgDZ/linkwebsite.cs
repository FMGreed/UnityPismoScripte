using UnityEngine;

public class linkwebsite : MonoBehaviour
{
	
	//javni unos teksta wwb stranice preko varijable websiteAddressees
    public string websiteAddress;
	
	//javna metoda za otvaranje linka preko web browsera
    public void OpenURLOnClick()
    {
        //otvaranje vanjske aplikacije preko OpenURL-a, otvaramo ono što piše u stringu websiteAddress...
        Application.OpenURL(websiteAddress);
    }
	
}