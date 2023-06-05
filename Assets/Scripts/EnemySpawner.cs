using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using WithIndex;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Dragons;
    public int chanceIn100 = 100;
    public int interval = 60;
    public float[] boundx = new float[] {-4.1f,4.1f};
    public float[] boundy = new float[] {-1.1f,2.1f};
    public float[] boundz = new float[] {3.1f,8.1f};
    public Vector3[] StartPositions = new Vector3[] { 
        new Vector3(-2.2f,0f,16.7f), 
        new Vector3(2.1f,0f,13.6f), 
        new Vector3(5.8f,0f,16.9f)
    };
    private int countdown = 0;
    private int childcount = 0;
    public Quaternion rotation = Quaternion.Euler(0, 180, 0);
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
        childcount = transform.childCount;
    }

    void Construir() {
        if ((gm.gameState == GameManager.GameState.GAME) && (gm.reset)) {
            countdown = 0;
            foreach (Transform child in transform){
                    GameObject.Destroy(child.gameObject);
            }
            foreach (var (position, index) in StartPositions.WithIndex()){
            // foreach (Vector3 posicao in StartPositions){
                    int enemy = (index % 3);
                    Instantiate(Dragons[enemy],position, rotation, transform);
                }
            childcount = transform.childCount;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == GameManager.GameState.GAME) {
            childcount = transform.childCount;
            countdown += 1;
            if (countdown >= interval + childcount*10 -100 - gm.score *2) {
                countdown = 0;
                if (childcount < 30) {
                    int roll = Random.Range(0,100);
                    if ((roll <= chanceIn100) || (childcount < 3)) {
                        int enemy = Random.Range(0,Dragons.Length);
                        Vector3 position = new Vector3(
                            Random.Range(boundx[0],boundx[1]),
                            Random.Range(boundy[0],boundy[1]),
                            Random.Range(boundz[0],boundz[1])
                        );
                        Instantiate(Dragons[enemy],position, rotation, transform);
                    }
                }
            }
        }
    }

}
