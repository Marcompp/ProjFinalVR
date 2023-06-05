using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int velocity = 50;
    public int deloadinterval = 1;
    public bool onhitdeload = true;
    
    //CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        print("shot");
        //characterController = GetComponent<CharacterController>();
        Invoke("DeLoad",deloadinterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  transform.forward * (velocity)* Time.deltaTime;
        //characterController.Move(transform.forward * (velocity)* Time.deltaTime);
    }

    void DeLoad() {
        print("bout");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider col) {
        //start sound;
        if (col.gameObject.CompareTag("Enemy")) {
            if (onhitdeload) {
                Destroy(this.gameObject);
            }
        }
    }
}
