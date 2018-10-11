using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startyMoney = 350;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start ()
    {
        Money = startyMoney;
        Lives = startLives;

        Rounds = 0;
    }


}
