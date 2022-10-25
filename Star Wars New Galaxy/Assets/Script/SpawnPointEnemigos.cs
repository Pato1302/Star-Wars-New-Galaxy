using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointEnemigos : MonoBehaviour
{
    public GameObject Clones;
    public float TiempoSpawn;
    public int TiempoDeSpawn;
    public Transform respawn;
    public Text ContadorText;
    public static int Contador;
    public static int ClonesRestantes;
    public Text ClonesRestantesText;

    // Start is called before the first frame update
    void Start()
    {
        ClonesRestantes = 10;
        Invoke("GetText", 1.0f);
    }
    public void GetText()
    {
        ContadorText = GameObject.Find("Contador").GetComponent<Text>();
        Contador = Contador + 10;
        //ClonesRestantesText.text = "Enemigos = " + ClonesRestantes.ToString(); // <----
    }

    // Update is called once per frame
    void Update()
    {
        ClonesRestantesText.text = "Enemigos = " + ClonesRestantes.ToString(); // <----
        if (Contador > 0)
        {
            TiempoSpawn -= Time.deltaTime;
            if (TiempoSpawn <= 0)
            {
                Instantiate(Clones, transform.position, transform.rotation);
                TiempoSpawn = TiempoDeSpawn;
                Contador = Contador - 1;
            }
        }
    }
}
//player.GetComponent<ControlBD1>().Damage();