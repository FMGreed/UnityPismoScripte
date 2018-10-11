using UnityEngine;
using System;

// specificirana publična klasa pod imenom CoinMagnet : Consumable 
public class CoinMagnet : Consumable  
{
    // zaštičeni parametar (Vector3) koji nemože biti modificiran faktorima u igri i može se samo čitati
    protected readonly Vector3 k_HalfExtentsBox = new Vector3(20.0f, 1.0f, 1.0f);
    // zaštićena constanta integer 
    protected const int k_LayerMask = 1 << 8;

    // publično prepisivanje valute stringa pod specifičnim imenom
    public override string GetConsumableName()
    {
        //prekid metode u kodu
        return "Magnet"; 
    }

    // publično prepisivanje enumeracijske vrijednosti
    public override ConsumableType GetConsumableType()
    {
        //prekid metode u kodu
        return ConsumableType.COIN_MAG;
    }

    // publično prepisivanje integera specificiranog u kodu
    public override int GetPrice()
    {
        //prekid metode u kodu
        return 750;
    }

    // publično prepisivanje integera specificiranog u kodu
    public override int GetPremiumCost()
	{
        //prekid metode u kodu
        return 0;
	}
    // zastičena klassa "Collider" sa vlastitom vrijednošću
	protected Collider[] returnColls = new Collider[20];

    // publično prepisivanje metode za vračanje specifirane kao "Tick"
    public override void Tick(CharacterInputController c)
    {
        // glavni trigger Tick
        base.Tick(c);

        // specifični integer za nekolko osobina u kodu
        int nb = Physics.OverlapBoxNonAlloc(c.characterCollider.transform.position, k_HalfExtentsBox, returnColls, c.characterCollider.transform.rotation, k_LayerMask);

        // dio koda koji specifira za koga/što je
        for(int i = 0; i< nb; ++i)
        {
			Coin returnCoin = returnColls[i].GetComponent<Coin>();
            // kod koji govori što bi se desilo ako odrađeni paramerti su nađeni u igri
			if (returnCoin != null && !returnCoin.isPremium && !c.characterCollider.magnetCoins.Contains(returnCoin.gameObject))
			{
				returnColls[i].transform.SetParent(c.transform);
				c.characterCollider.magnetCoins.Add(returnColls[i].gameObject);
			}
		}
    }
}
