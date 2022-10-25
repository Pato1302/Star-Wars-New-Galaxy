using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TpNiv2 : MonoBehaviour
{
    public static int Prueba;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Prueba == 0)
        {

        }
    }
    public void TeleportNiv2()
    {
 
    }
    private void OnTriggerEnter(Collider other)
    {
        int Eliminados;
        if ((player.GetComponent("PlayerControl") as PlayerControl) != null)
        {
            Eliminados = PlayerControl.NumEnemies;
        }
        else
        {
            Eliminados = ControlBD1.NumEnemies;
        }
        Debug.Log(SpawnPointEnemigos.ClonesRestantes);
        if (other.CompareTag("Player") && SpawnPointEnemigos.ClonesRestantes==0)
        {
            SceneManager.LoadScene("Sample Scene");
        }
    }
}
