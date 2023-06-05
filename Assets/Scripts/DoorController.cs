using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class DoorController : MonoBehaviour
{
    private Rigidbody rb;
    public int[] password = {1,5,3,2};
    private int[] inputed = {0,0,0,0};
    private bool open = false;
    static int input;
    private AudioSource soundSource;
    public AudioClip success;
    public AudioClip buzzer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    static public void teste() {
        print("A");
    }

    public void addInput(int input) 
    {
        if (!open) {
            for (int inn = 0; inn < inputed.Length; inn++) {
                if (inputed[inn] == 0) 
                {
                    inputed[inn] = input;
                    Debug.Log(inputed);
                    break;
                }
            }
            if (inputed[3] != 0) {
                if (inputed.SequenceEqual(password)) {
                    soundSource.PlayOneShot(success);

                    open = true;
                    rb.velocity = new Vector3(0,2,0);
                }
                else {
                    soundSource.PlayOneShot(buzzer);

                    inputed = new int[] {0,0,0,0};
                }
            }
        }
    }
}
