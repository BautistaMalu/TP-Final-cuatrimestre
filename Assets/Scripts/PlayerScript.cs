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
    public GameObject SpikesIzq;
    int cantidad = 1;
    int maximo = 2;
    GameObject clon;
    public GameObject SpikesDer;
    GameObject clon2;
    public Text contadortext;
    public AudioClip Bonk;
    AudioSource fuente;
    Time time;
    public Text TimeText;
    float starttime;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        fuente = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        starttime = Time.timeSinceLevelLoad;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

        }

        transform.Translate(0, movementspeed, 0);



        if (contador > 0)
        {
            contadortext.text = ("Puntaje:" + contador.ToString());

        }

        if (contador == 10)
        {
            contadortext.text = ("Ganaste");
            gameObject.SetActive(false);
        }

        if (lifeandrestart.Life == 100)
        {
            TimeText.text = ("Segundos:" + Mathf.Floor(starttime).ToString());
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
        if (col.gameObject.name == "SpikesIzqVariant(Clone)")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
            lifeandrestart.Life -= 100;
  

        }
        if (col.gameObject.name == "SpikesDerVariant(Clone)")
        {
            transform.position = new Vector3(-1.45f, 7, -3);

            contador = 0;
            lifeandrestart.Life -= 100;

        }

        else if (col.gameObject.name == "ParedIzq")
        {

            transform.Translate(0, movementspeed, 0);

            movementspeed = movementspeed + (movementspeed * -2);



            contador++;

            while (cantidad <= maximo)
            {
                clon = Instantiate(SpikesDer, PositionDer(), Quaternion.identity);
                clon.transform.eulerAngles = new Vector3(0, -90, 0);
                cantidad++;
                Destroy(clon, 4.5f);
            }

            maximo++;
            cantidad = 1;
            fuente.clip = Bonk;
            fuente.Play();
        }
        else if (col.gameObject.name == "ParedDer")
        {

            transform.Translate(0, movementspeed, 0);

            movementspeed = movementspeed - (movementspeed * 2);





            contador++;

            while (cantidad <= maximo)
            {
                clon2 = Instantiate(SpikesIzq, PositionIzq(), Quaternion.identity);
                clon2.transform.eulerAngles = new Vector3(0, 90, 0);
                cantidad++;
                Destroy(clon2, 4.5f);
            }
            cantidad = 1;

            fuente.clip = Bonk;
            fuente.Play();
        }
    }
    Vector3 PositionDer()
    {
        float x, y, z;
        x = 19.3f;
        y = UnityEngine.Random.Range(-17.3f, 29.3f);
        z = 2.3f;

        return new Vector3(x, y, z);
    }
    Vector3 PositionIzq()
    {
        float x, y, z;
        x = -20.1f;
        y = UnityEngine.Random.Range(-17.3f, 29.3f);
        z = -2.7f;

        return new Vector3(x, y, z);
    }

    /*Quaternion rotacionizq()
    {
        float x, y, z;
        x = 90;
        y = 90;
        z = 0;

        return new Quaternion(x, y, z);

    }*/

}
