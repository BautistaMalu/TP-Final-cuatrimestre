using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float jumpforce;
    Rigidbody rb;
    public float movementspeed;
    int contador = 0;
    public Material mat;
    public GameObject SpikesIzq;
    int cantidad = 1;
    int maximo = 4;
    GameObject clon;
    public GameObject SpikesDer;
    GameObject clon2;
    public Text contadortext;
    public Text win;
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



        if (contador > 0)
        {
            contadortext.text = ("Puntaje:" + contador.ToString());

        }

        if (contador == 10)
        {
            contadortext.text = ("Ganaste");
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Spikes")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
            lifeandrestart.Life -= 100;


        }
        if (col.gameObject.name == "SpikesIzq(Clone)")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
            lifeandrestart.Life -= 100;
  

        }
        if (col.gameObject.name == "SpikesDer(Clone)")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
            lifeandrestart.Life -= 100;

        }

        else if (col.gameObject.name == "ParedIzq")
        {

            transform.Translate(movementspeed, 0, 0);

            movementspeed = movementspeed + (-movementspeed * 2);

            contador++;

            mat.color = Color.blue;

            while (cantidad <= maximo)
            {
                clon = Instantiate(SpikesDer, PositionDer(), Quaternion.identity);
                cantidad++;
                Destroy(clon, 4.5f);
            }

            maximo++;
            cantidad = 1;
        }
        else if (col.gameObject.name == "ParedDer")
        {

            transform.Translate(movementspeed, 0, 0);

            movementspeed = movementspeed - (movementspeed * 2);

            contador++;

            mat.color = Color.green;

            while (cantidad <= maximo)
            {
                clon2 = Instantiate(SpikesIzq, PositionIzq(), Quaternion.identity);
                cantidad++;
                Destroy(clon2, 4.5f);
            }
            cantidad = 1;
        }
    }
    Vector3 PositionDer()
    {
        float x, y, z;
        x = 17;
        y = UnityEngine.Random.Range(-17.3f, 33.1f);
        z = -2.7f;

        return new Vector3(x, y, z);
    }
    Vector3 PositionIzq()
    {
        float x, y, z;
        x = -17.7f;
        y = UnityEngine.Random.Range(-17.3f, 33.1f);
        z = -2.7f;

        return new Vector3(x, y, z);
    }

}
