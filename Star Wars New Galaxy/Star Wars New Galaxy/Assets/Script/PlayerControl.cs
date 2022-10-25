using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CollectFX;
    public vThirdPersonCamera tpc;
    public Transform shootPoint;
    public GameObject bullet;
    public GameObject shootPointFX;
    public static int Balas; // <---- ==AQUÍ==
    public Text balasText;
    public float health = 1.0f;
    public Image healthbar;
    public static int NumEnemies;
    void Start()
    {
        NumEnemies = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        tpc = GameObject.Find("vThirdPersonCamera").GetComponent<vThirdPersonCamera>();
        healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
        balasText = GameObject.Find("Balas").GetComponent<Text>();
    }
    public void EnemyKilled()
    {
        NumEnemies = NumEnemies + 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balas"))
        {
            Balas = Balas + 5;
            balasText.text = "Balas = " + Balas.ToString();
            Destroy(other.gameObject);
            Instantiate(CollectFX, other.transform.position, other.transform.rotation);
            PlayerPrefs.SetInt("Balas", Balas); // <---- ==AQUÍ==
        }
        if (other.CompareTag("Health"))
        {
            health = health + 0.5f;
            healthbar.fillAmount = health;
            Destroy(other.gameObject);
            Instantiate(CollectFX, other.transform.position, other.transform.rotation);
        }
    }
    public void Damage()
    {
        health = health - 0.05f;
        healthbar.fillAmount = health;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<Animator>().SetTrigger("Dance");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Animator>().SetTrigger("Patada");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Apuntar",true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Apuntar", false);
        }
        if (Input.GetMouseButton(1)) {//Clic Derecho de Mouse
            tpc.height = 2.08f;
            tpc.rightOffset = 0.37f;
            tpc.defaultDistance = 2.15f;

            Vector3 dir = tpc.transform.forward;
            dir.y = 0;
            Quaternion r = Quaternion.LookRotation(dir);
            transform.rotation = r;
        }
        if (Input.GetMouseButtonUp(1))
        {
            tpc.height = 1.77f;
            tpc.rightOffset = 0.0f;
            tpc.defaultDistance = 3.07f;
        }
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && Balas>0)
        {
            Vector3 to;
            RaycastHit hit;
            if (Physics.Raycast(tpc.transform.position, tpc.transform.forward, out hit))
                to = hit.point;
            else
                to = tpc.transform.forward * 100;
            Vector3 from = shootPoint.position;
            Vector3 dif = to - from;
            Quaternion q = Quaternion.LookRotation(dif);
            GameObject g = Instantiate(bullet, shootPoint.position, q);
            g.transform.Rotate(90, 0, 0);
            g.GetComponent<Rigidbody>().AddForce(dif.normalized * 300);
            Instantiate(shootPointFX, shootPoint.position, shootPoint.rotation);
            Balas = Balas - 1;
            balasText.text = "Balas = " + Balas.ToString();
        }
    }
}
