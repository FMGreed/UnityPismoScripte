using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Lista sa poljima")]
    public Text[] spaceList;
    [Header("Game over panel (UI)")]
    public GameObject gameOver; //Panel u pozadini da sakrije polje
    public GameObject restartButton;
    public Text gameOver_text; //Text koji prikazuje rezultat (X pobjedio, O pobjedio, nerješeno)
    
    public int moves; //Kolko poteza imamo
    [SerializeField]
    string side; //Može biti samo "X" ili "Ö"

    void Start()
    {
        SetGController4Buttons(); //metoda odmah ispod starta
        side = "X"; //Počinjemo sa znakom "X"
        gameOver.SetActive(false); //Isključi gameoverPanel za svaki slučaj
        gameOver_text.text = ""; //Resetira text na prazno
        moves = 0; //Broj poteza na početku neka bude 0
        //restartButton.SetActive(false); //Možemo imati uključeno ili isključeno po izboru
    }

    void SetGController4Buttons() //SetGameControllerReferenceForButtons --> Dodjeljujemo svakom mjestu u listi broj/referencu
    {
        for (int i = 0; i < spaceList.Length; i++)
        {
            spaceList[i].GetComponentInParent<Space>().SetControllerReferences(this);
        }
    }
    public void ChangeSide() //Mjenja strane && znakove
    {
        if(side == "X")
        {
            side = "Ö";
        }
        else
        {
            side = "X";
        }
    }
    public string GetSide()
    {
        return side;
    }
    public void EndTurn() //Metoda sa uvijetima za kraj igre
    {
        if(spaceList[0].text == side && spaceList[1].text == side && spaceList[2].text == side)
        {
            GameOver();
        }
        else if(spaceList[3].text == side && spaceList[4].text == side && spaceList[5].text == side)
        {
            GameOver();
        }
        else if (spaceList[6].text == side && spaceList[7].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[3].text == side && spaceList[6].text == side)
        {
            GameOver();
        }
        else if (spaceList[1].text == side && spaceList[4].text == side && spaceList[7].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[5].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[4].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[4].text == side && spaceList[6].text == side)
        {
            GameOver();
        }

        else if (moves >= 9) // 9 jer je 9 polja, dakle max 9 poteza
        {
            gameOver.SetActive(true);
            gameOver_text.text = "Tie!";
            //restartButton.SetActive(true);
        }

        ChangeSide();
    }
    void GameOver()
    {
        gameOver.SetActive(true);
        gameOver_text.text = side + " wins!";
        //restartButton.SetActive(true);

        for (int i = 0; i < spaceList.Length; i++)
        {
            SetInteractable(false);
        }
    }

    void SetInteractable(bool setting)
    {
        for (int i = 0; i < spaceList.Length; i++)
        {
            spaceList[i].GetComponentInParent<Button>().interactable = setting;
        }
    }

    public void Restart()
    {
        side = "X";
        moves = 0;
        gameOver.SetActive(false);
        gameOver_text.text = "";
        SetInteractable(true);
        //restartButton.SetActive(false);

        for (int i = 0; i < spaceList.Length; i++)
        {
            spaceList[i].text = "";
        }
    }
}
