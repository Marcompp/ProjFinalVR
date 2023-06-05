

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FireballController : MonoBehaviour
{
    public int velocity = 3;
    public float flashinterval = 0.3f;
    public Material HUD;
    
    //Image im;
    Color originalColor;

    
    GameManager gm;
    
    //CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        print("shot");
        //characterController = GetComponent<CharacterController>();
        //im = HUD.GetComponent<Image>();
        //originalColor = im.color;
        originalColor = new Color(0,0,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == GameManager.GameState.GAME) {
            transform.position +=  transform.forward * (velocity)* Time.deltaTime;
        }
        if ((gm.gameState == GameManager.GameState.GAMEOVER) || (gm.gameState == GameManager.GameState.VICTORY) || (gm.gameState == GameManager.GameState.MENU)) {
            HUD.color = originalColor;
            Destroy(this.gameObject);
        }
        //characterController.Move(transform.forward * (velocity)* Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col) {
        //start sound;
        print("FOOOOOOOOOOSH!");
        print(col.gameObject.tag);
        if (col.gameObject.CompareTag("Projectile")) {
            Destroy(this.gameObject);
        }
        else {
            if (col.gameObject.CompareTag("Castle")) {
                gm.hp -= 1;
                if(gm.hp <= 0 && gm.gameState == GameManager.GameState.GAME)
                {
                    gm.ChangeState(GameManager.GameState.GAMEOVER);
                    Destroy(this.gameObject);
                }
                else {  
                    HUD.color = new Color(1,0,0,0.5f);
                    Invoke("ResetFlash",flashinterval);
                }
                
            }
        }
    }

    void ResetFlash(){
        print("RESTORE");
        if (gm.gameState == GameManager.GameState.GAME) {
            HUD.color = originalColor;
            Destroy(this.gameObject);
        }
        else {
            Invoke("ResetFlash", flashinterval);
        }
    }
}
