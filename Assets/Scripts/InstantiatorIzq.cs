using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorIzq : MonoBehaviour
{
    public GameObject Spikes;
    int cantidad = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            while (11 > cantidad)
            {
                Instantiate(Spikes, Positionn(), Quaternion.identity);
                cantidad++;
            }
        }
    }

    Vector3 Positionn()
    {
        float x, y, z;
        x = 17;
        y = UnityEngine.Random.Range(-17.3f,33.1f);
        z = -2.7f;

        return new Vector3(x, y, z);
    }
}
