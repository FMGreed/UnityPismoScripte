using UnityEngine;

//Javna klasa PlayerController sluzi za kontrolu objekta tj. Playera u igri (koristenje WASD i strelica na tipkovnici)
public class PlayerController : MonoBehaviour
{
    //funkcija koja se osvježava svaki frame
    void Update()
    {
        //varijable koje primaju x i z os 
        //Time.deltaTime - vrijeme u sekundama koje je potrebno da se odradi zadnji frame
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;

        //mnozenjem Time.deltaTime i float vrijednosti pomicemo objekt xx metara u sekundi

        //pomicanje objekta po x i z osi
        transform.Translate(0, x, z);
    }
}



