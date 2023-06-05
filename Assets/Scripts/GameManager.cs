using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public enum GameState { MENU, GAME, PAUSE, GAMEOVER, VICTORY };

    public GameState gameState { get; private set; }
    public int hp;
    public int score;
    public bool reset;

    private static GameManager _instance;


    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
           _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        hp = 10;
        score = 0;
        reset = false;
        gameState = GameState.MENU;
        Time.timeScale = 1;
    }

    
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (gameState == GameState.GAMEOVER && nextState == GameState.GAME) {
            Time.timeScale = 1;
            Reset();
            reset = true;
        }
        if (gameState == GameState.GAMEOVER && nextState == GameState.MENU) {
            Reset();
            reset = true;
        }
        if (gameState == GameState.VICTORY && nextState == GameState.GAME) {
            Time.timeScale = 1;
            Reset();
            reset = true;
        }
        if (gameState == GameState.VICTORY && nextState == GameState.MENU) {
            Reset();
            reset = true;
        }
        if (gameState == GameState.MENU && nextState == GameState.GAME) {
            Time.timeScale = 1;
            reset = true;
        }
        if (gameState == GameState.GAME && nextState == GameState.PAUSE) {
            Time.timeScale = 1;
            reset = true;
        }
        if (gameState == GameState.GAME && nextState == GameState.GAMEOVER) {
            Time.timeScale = 1;
        }
        if (gameState == GameState.GAME && nextState == GameState.VICTORY) {
            Time.timeScale = 1;
        }
        if (gameState == GameState.PAUSE && nextState == GameState.GAME) {
            Time.timeScale = 1;
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        hp = 10;
        score = 0;
    }

}