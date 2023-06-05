using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherController : MonoBehaviour
{
    public int goal = 100;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //do stuff
            if (gm.gameState == GameManager.GameState.GAME) {
                gm.ChangeState(GameManager.GameState.PAUSE);
            }
            else if (gm.gameState == GameManager.GameState.PAUSE) {
                gm.ChangeState(GameManager.GameState.GAME);
            }

            if((gm.score >= goal) && (gm.gameState == GameManager.GameState.GAME)) {
                gm.ChangeState(GameManager.GameState.VICTORY);
            }
        }
    }
}
