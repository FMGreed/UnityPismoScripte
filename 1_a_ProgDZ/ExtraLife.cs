using UnityEngine;
using System;
// specificirana publična klasa pod imenom ExtraLife : Consumable 
public class ExtraLife : Consumable
{   
    //Dvije zaštičene konstante integera, ne može se promjeniti tokom igre
    protected const int k_MaxLives = 3;
    protected const int k_CoinValue = 10;

    // publično prepisivanje valute stringa pod specifičnim imenom
    public override string GetConsumableName()
    {
        //vrati valutu specifiranu u kodu
        return "Life";
    }
    // publično prepisivanje enumeracijske vrijednosti
    public override ConsumableType GetConsumableType()
    {
        //vrati valutu specifiranu u kodu
        return ConsumableType.EXTRALIFE;
    }
    // publično prepisivanje integera specificiranog u kodu
    public override int GetPrice()
    {
        //vrati valutu specifiranu u kodu
        return 2000;
    }
    // publično prepisivanje integera specificiranog u kodu
    public override int GetPremiumCost()
	{
        //vrati valutu specifiranu u kodu
        return 5;
	}
    // publično prepisivanje booleana(0 ili 1) specificiranog u kodu
    public override bool CanBeUsed(CharacterInputController c)
    { 
        //Sekcija koda koja uglavnom sljedi bool class koja određuje koja se akcija odvija ako upisani parametar je lažan ili točan
        if (c.currentLife == c.maxLife)
            //vrati valutu specifiranu u kodu
            return false;
        //vrati valutu specifiranu u kodu
        return true;
    }
    // publično prepisivanje metode za vračanje specifirane kao "Started"
    public override void Started(CharacterInputController c)
    {
        // kod specifirane baze koja je prepisana zbog druge metode
        base.Started(c);
        // U slučaju specifirane vrijednosti da dođe do zadane akcije
        if (c.currentLife < k_MaxLives)
            c.currentLife += 1;
        // u slučaju da gornja vrijednost nije aktivirana
		else
            c.coins += k_CoinValue;
    }
}
