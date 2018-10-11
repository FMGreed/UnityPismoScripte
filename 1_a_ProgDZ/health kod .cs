using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


 public class Health : MonoBehaviour
       //javni int koji|nam pokazuje iznos maximalnog health-a
       public int maxHealth = 100;
       //javni int za primanje štete 
       public int TakeDamage (int amount ){
       //varijabla koja nam služi da ukoliko naš Health dođe do 0 ili manje od 0 pali akciju dead 	
       	currentHealth -= amount ;
       	if (currentHealth <= 0);
       	{
       		currentHealth = 0;
       		Debug.log("dead!");
       	}
       }
}