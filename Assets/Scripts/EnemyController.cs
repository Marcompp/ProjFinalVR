using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using Enumerable;

public class EnemyController : MonoBehaviour
{
    public int hp = 1;
    public float _gravidade = 1f;
    public float speed = 1.0f;
    public int atkinterval = 60;
    public int atkchance = 10;
    private int deadinterval = 1;
    private bool dead = false;
    private Animator animator;
    CharacterController characterController;
    private int countdown = 0;
    Color originalColor;
    public float flashinterval = 1f;
    public GameObject Fireball;
    public GameObject[] MuzzlePoints;
    public float atkduration;
    public float[] fballdelays;
    private bool attacking;
    private int breath;
    private Material mat;
    private bool testc;
    private float velocity;
    private GameObject child;
    private CapsuleCollider ccollider;
    private BoxCollider bcollider;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        velocity = speed;
        gm = GameManager.GetInstance();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        child = this.gameObject.transform.GetChild(0).gameObject;
        mat = child.GetComponent<SkinnedMeshRenderer>().material;
        //GameManager.changeStateDelegate += PauseAnimation;
        ccollider = GetComponent<CapsuleCollider>();
        bcollider = GetComponent<BoxCollider>();
        //mat = Instantiate(mat as Material);
        originalColor = mat.color;
        testc = true;
        Invoke("BreathAttack",atkinterval);
        breath = 0;
    }

    void PauseAnimation() {
        if (gm.gameState == GameManager.GameState.GAME) {
            animator.speed = 1;
        }
        else {
            animator.speed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking) {
            //breath = 0;
        }
        PauseAnimation();
        if (gm.gameState == GameManager.GameState.GAME) {
            
            if (dead) {
                characterController.Move(transform.up * (-_gravidade)* Time.deltaTime);
            }
            else {
                if (transform.position.z > 5) {
                    characterController.Move(transform.forward * (velocity)* Time.deltaTime);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider col) {
        //start sound;
        print("ACERTOU");
        print(col.gameObject);
        if (col.gameObject.CompareTag("Projectile")) {
            if (!dead) {
                print("MORREU");
                mat.color = Color.red;
                Invoke("ResetColor", flashinterval);
                hp -=1;
                if (hp <= 0) {
                    if (!dead) {
                        gm.score +=1;
                    }
                    dead = true;
                    animator.SetTrigger("Dead");
                    Invoke("DeadFade",deadinterval);
                    bcollider.enabled =false;
                    ccollider.enabled =false;
                    CancelInvoke("BreathAttack");
                    CancelInvoke("BreatheFball");
                    CancelInvoke("EndAttack");
                }
            }
        }
    }

    void BreathAttack(){
        print("HEYHO");
        if (gm.gameState == GameManager.GameState.GAME) {
            int roll = Random.Range(0,100);
            if (roll <= atkchance) {
                    print("AATTAACKK");
                    velocity = 0;
                    animator.SetTrigger("Attack");
                    attacking = true;
                    Invoke("BreatheFball",fballdelays[0]);
                    Invoke("EndAttack",atkduration);
                    Invoke("BreathAttack",2*atkinterval);     
            }
            else{
                Invoke("BreathAttack",atkinterval); 
            }
        }
        else {
            Invoke("BreathAttack",atkinterval); 
        }
    }

    void BreatheFball(){
        if (gm.gameState == GameManager.GameState.GAME) {
            print("hihi");
            Instantiate(Fireball,MuzzlePoints[breath].transform.position,transform.rotation);
            breath +=1;
            if (breath < MuzzlePoints.Length) {
                Invoke("BreatheFball",fballdelays[breath]);
            }
        }
        else {
            Invoke("BreatheFball",fballdelays[breath]);
        }
    }

    void EndAttack(){
        if (gm.gameState == GameManager.GameState.GAME) {
            attacking = false;
            velocity = speed;
            breath = 0;
        }
        else {
            Invoke("BreatheFball",fballdelays[breath]);
        }
        animator.ResetTrigger("Attack");
    }

    

    void DeadFade(){
        if (gm.gameState == GameManager.GameState.GAME) {
            print("ouo");
            Destroy(this.gameObject);
        }
        else {
            Invoke("DeadFade",deadinterval);
        }
    }

    void ResetColor(){
        if (gm.gameState == GameManager.GameState.GAME) {
            mat.color = originalColor;
        }
        else {
            Invoke("ResetColor", flashinterval);
        }
    }
}
