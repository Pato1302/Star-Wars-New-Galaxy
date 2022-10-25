using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointControl : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public Text balasText; // <---- ==AQUÍ==
    //public int Balas2;  // <---- ==AQUÍ==
    // Start is called before the first frame update
    void Start()
    {
        int character = PlayerPrefs.GetInt("Character");
        int Balas = PlayerPrefs.GetInt("Balas");  // <---- ==AQUÍ==
        if (character == 1)
        {
            Instantiate(prefab1, transform.position, transform.rotation);
        }
        if (character == 2)
        {
            Instantiate(prefab2, transform.position, transform.rotation);
            Balas = PlayerControl.Balas; // <---- ==AQUÍ==
            balasText.text = "Balas = " + Balas.ToString(); // <---- ==AQUÍ==
        }
        if (character == 3)
        {
            Instantiate(prefab3, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
