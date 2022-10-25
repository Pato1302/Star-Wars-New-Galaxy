using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TPNiv3 : MonoBehaviour
{
    public static int Prueba;
    public GameObject player;
    public float timeValue = 90;
    public Text Tempo;
    public GameObject botiquin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Tempo = GameObject.Find("Tempo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            Tempo.text = "Time = " + timeValue.ToString();
        }
        else
        {
            timeValue = 0;
            Tempo.text = "Ve a la salida";
        }
    }

    public void TeleportNiv2()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && timeValue<=0)
        {
            SceneManager.LoadScene("Jedi_Fuera");
        }
    }
}
