using UnityEngine;
using System;

public class Invincibility : Consumable
{
    // publično prepisivanje valute stringa pod specifičnim imenom
    public override string GetConsumableName()
    {
        //vrati valutu specifiranu u kodu
        return "Invincible";
    }
    // publično prepisivanje enumeracijske vrijednosti
    public override ConsumableType GetConsumableType()
    {
        //vrati valutu specifiranu u kodu
        return ConsumableType.INVINCIBILITY;
    }
    // publično prepisivanje integera specificiranog u kodu
    public override int GetPrice()
    {
        //vrati valutu specifiranu u kodu
        return 1500;
    }
    // publično prepisivanje integera specificiranog u kodu
    public override int GetPremiumCost()
	{
        //vrati valutu specifiranu u kodu
        return 5;
	}
    // publično prepisivanje metode za vračanje specifirane kao "Tick"
    public override void Tick(CharacterInputController c)
    {
        // kod specifirane baze koja je prepisana zbog druge metode
        base.Tick(c);

        c.characterCollider.SetInvincibleExplicit(true);
    }
    // publično prepisivanje metode za vračanje specifirane kao "Started"
    public override void Started(CharacterInputController c)
    {
        // kod specifirane baze koja je prepisana zbog druge metode
        base.Started(c);
        c.characterCollider.SetInvincible(duration);
    }
    // publično prepisivanje metode za vračanje specifirane kao "Ended"
    public override void Ended(CharacterInputController c)
    {
        // kod specifirane baze koja je prepisana zbog druge metode
        base.Ended(c);
        c.characterCollider.SetInvincibleExplicit(false);
    }
}
