using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public float shotinterval = 0.5f;
    private bool shooting = false;
    public GameObject muzzle;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        //Instantiate(Bullet);
        //Invoke("FireGun",shotinterval);
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(Bullet,transform.position,transform.rotation);
    }

    public void StartGun() {
        shooting = true;
        FireGun();
        
        print("STARTMASSACRE");
    }

    public void StopGun() {
        CancelInvoke("FireGun");
        shooting = false;
        print("STOPMASSACRE");
    }

    public void FireGun() {
        
        if (shooting) {
            
            if (gm.gameState == GameManager.GameState.GAME) {
                print("hihi");
                Instantiate(Bullet,muzzle.transform.position,transform.rotation);
            }
            Invoke("FireGun",shotinterval);
        }
    }
}
