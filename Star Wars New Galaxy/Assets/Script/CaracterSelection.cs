using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaracterSelection : MonoBehaviour
{
    public GameObject selection1;
    public GameObject selection2;
    public GameObject selection3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selection1.SetActive(true);
            selection2.SetActive(false);
            selection3.SetActive(false);
            PlayerPrefs.SetInt("Character", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selection1.SetActive(false);
            selection2.SetActive(true);
            selection3.SetActive(false);
            PlayerPrefs.SetInt("Character", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selection1.SetActive(false);
            selection2.SetActive(false);
            selection3.SetActive(true);
            PlayerPrefs.SetInt("Character", 3);
        }
    }
    public void Go()
    {
        SceneManager.LoadScene("DesertScene_mobile");
        //SceneManager.LoadScene("Cami Nv1", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Rami Nv1", LoadSceneMode.Additive);
    }
}
