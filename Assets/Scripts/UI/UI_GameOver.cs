using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        /*
        if(gm.vidas > 0)
        {
            message.color = Color.cyan;
            message.text = "Victory!!!";
        }
        else
        {
            message.color = Color.red;
            message.text = "GAME OVER";
        }*/
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
    public void Menu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}