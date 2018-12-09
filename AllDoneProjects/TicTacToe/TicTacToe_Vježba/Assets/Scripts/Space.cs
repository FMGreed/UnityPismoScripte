using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour
{
    public Button btn;
    public Text btn_text;

    GameManager gameManager;

    public void SetControllerReferences(GameManager control)
    {
        gameManager = control;
    }

    public void SetSpace()
    {
        btn_text.text = gameManager.GetSide();
        btn.interactable = false;
        gameManager.moves += 1;
        gameManager.EndTurn();
    }
}