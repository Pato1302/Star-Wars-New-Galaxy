using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBD1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CollectFX;
    public vThirdPersonCamera tpc1;
    public int Balas;
    public Text balasText;
    public float health = 1.0f;
    public Image healthbar;
    public static int NumEnemies;
    void Start()
    {
        NumEnemies = 0;
        tpc1 = GameObject.Find("vThirdPersonCamara").GetComponent<vThirdPersonCamera>();
        healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
        balasText = GameObject.Find("Balas").GetComponent<Text>();
        balasText.text = "Sable";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetComponent<Animator>().SetBool("Collapse_GunShot", false);
    }

    public void EnemyKilled()
    {
        NumEnemies = NumEnemies + 1;
    }

    public void Inicio()
    {
        tpc1 = GameObject.Find("vThirdPersonCamera").GetComponent<vThirdPersonCamera>();
        healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
        balasText = GameObject.Find("Balas").GetComponent<Text>();
        balasText.text = "Sable";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
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
        
        //MODIFICACIONES
        if(health <= 0f)
        {
            GetComponent<Animator>().SetBool("Collapse_GunShot", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("Inicio", 1.0f);
        if (tpc1 = null) return;
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
            GetComponent<Animator>().SetBool("Apuntar", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Apuntar", false);
        }
        if (Input.GetMouseButton(1))
        {//Clic Derecho de Mouse
            tpc1.height = 2.08f;
            tpc1.rightOffset = 0.37f;
            tpc1.defaultDistance = 2.15f;

            Vector3 dir = tpc1.transform.forward;
            dir.y = 0;
            Quaternion r = Quaternion.LookRotation(dir);
            transform.rotation = r;
        }
        if (Input.GetMouseButtonUp(1))
        {
            tpc1.height = 1.77f;
            tpc1.rightOffset = 0.0f;
            tpc1.defaultDistance = 3.07f;
        }
    }
}
