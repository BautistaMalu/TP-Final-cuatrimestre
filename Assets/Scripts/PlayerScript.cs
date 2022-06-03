using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpforce;
    Rigidbody rb;
    public float movementspeed;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
 
        }

        transform.Translate(movementspeed, 0, 0);

        while (contador%2 == 1)
        {

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Spikes")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
        }

        else if (col.gameObject.name == "ParedIzq")
        {
            transform.Translate(movementspeed, 0, 0);

            movementspeed = movementspeed + (-movementspeed*2);

            contador++;
        }
        else if (col.gameObject.name == "ParedDer")
        {
            transform.Translate(movementspeed, 0, 0);

            movementspeed = movementspeed - (movementspeed * 2);

            contador++;
        }
    }

}
