using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lifeandrestart : MonoBehaviour
{
    public static int Life = 100;
    public GameObject player;
    public Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.enabled = false;

        if (Input.GetKeyDown(KeyCode.R))
         {
            SceneManager.LoadScene("SampleScene");
            Life = 100;
            player.SetActive(true);
         }

        if (Life == 0)
        {
            txt.enabled = true;
            player.SetActive(false);
            txt.text = ("Toca R para reiniciar");
        }
        
    }

}
