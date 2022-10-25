using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatoPlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int Sable;
    public Text sableText;
    public GameObject CollectFX;
    public vThirdPersonCamera tpc;
    public Transform shootPoint;
    public GameObject bullet;
    public GameObject shootPointFX;
    public int Balas;
    public Text balasText;
    public float health = 1.0f;
    public Image healthbar;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        tpc = GameObject.Find("vThirdPersonCamara").GetComponent<vThirdPersonCamera>();
        healthbar = GameObject.Find("HealthBar").GetComponent<Image>();
        balasText.text = "Sable";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sable"))
        {
            Sable = Sable + 1;
            sableText.text = "Sable";
            //rocketText.text =  "Rockets x " + rockets.ToString();      Profe, para agregar mas cohetes
            Destroy(other.gameObject);
            Instantiate(CollectFX, other.transform.position, other.transform.rotation);
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
    }
}
