using UnityEngine;
using System;

/// <summary>
/// Definicija igraca koja je spojena sa prefabima koji se nalaze u Bundles/Charachter folderu. I sadrži sve podatke vezane za igrača/lika
/// </summary>


public class Character : MonoBehaviour
{
    public string characterName;                    //javna varijabla za unos imena igrača
    public int cost;                                //javna varijabla za unos cijene game valute
	public int premiumCost;                         //javna varijabla za unos cijene premium valute

	public CharacterAccessories[] accessories;      //javna lista za nakit

    public Animator animator;                       //javna varijabla za animaciju
	public Sprite icon;                             //javna varijabla za ikonu

	[Header("Sound")]                               //pomoc pri organizaciji u inspektoru
	public AudioClip jumpSound;                     //javna varijabla za zvuk skoka
	public AudioClip hitSound;                      //javna varijabla za zvuk udarca
	public AudioClip deathSound;                    //javna varijabla za zvuk smrti

 
    //Igra se poziva na ovaj kod kade igrac promijeni nakit te omogućuje/onemogućuje children objekte prema tome
    //vrijednost od -1 u parametrima onemogućuje sve nakite
    public void SetupAccesory(int accessory)                                                //javna varijabla naziva setupaccesory za unos nakita koji se koristi
    {
        for (int i = 0; i < accessories.Length; ++i                                         //za postavljanje nakita kojeg igrac u igirici koristi u tom trenu
        {
            accessories[i].gameObject.SetActive(i == PlayerData.instance.usedAccessory);
        }
    }
}
