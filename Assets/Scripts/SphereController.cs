using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb; 
    [SerializeField] 
    private Text _text;
    [SerializeField] 
    private int value; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "endSphere")
        {
            _text.text = "Desafio III: " + value.ToString();
        }
    }
    
    public void to_up()
    {
        rb.velocity = new Vector3(0,(float)0.3,0);
    }

    public void to_down()
    {
        rb.velocity = new Vector3(0,(float)-0.3, 0);
    }

    public void to_right()
    {
        rb.velocity = new Vector3((float)0.3,0,0);
    }

    public void to_left()
    {
        rb.velocity = new Vector3((float)-0.3,0,0);
    }

    public void stop()
    {
        rb.velocity = new Vector3(0,0,0);
    }
}
