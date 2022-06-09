using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiatorDer : MonoBehaviour
{
    public GameObject Spikes;
    int cantidad = 1;
    int maximo = 4;
    GameObject clon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(clon, 3);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            while (cantidad < maximo)
            {
                clon = Instantiate(Spikes, Positionn(), Quaternion.identity);
                cantidad++;
            }
            maximo++;
            cantidad = 1;

            
        }
    }

    Vector3 Positionn()
    {
        float x, y, z;
        x = -17.7f;
        y = UnityEngine.Random.Range(-17.3f, 33.1f);
        z = -2.7f;

        return new Vector3(x, y, z);
    }
}

