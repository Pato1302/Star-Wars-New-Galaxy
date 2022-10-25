using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent_Control : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public string status;
    public Animator animator;

    public float time;
    public Transform shootpoint;
    public GameObject shootpointFX;
    public GameObject impactpointFX;

    public GameObject Recompensa;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Invoke("GetPlayerReference", 1.0f);
        status = "Chasing";
    }
    public void GetPlayerReference()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Distance", distance);
        animator.SetFloat("Speed", speed);
        if (status == "Chasing") animator.SetBool("Chasing", true);
        else animator.SetBool("Chasing", false);


        if (status == "Chasing")
        {
            agent.SetDestination(player.transform.position);
            if (distance < 5.0f)
            {
                status = "Shooting";
                agent.isStopped = true;
                Invoke("Shoot", time);
            }
        }
        else if (status == "Shooting")
        {
            Vector3 to = player.transform.position + new Vector3(0, 0.5f, 0);
            Vector3 from = shootpoint.position;
            Vector3 dif = to - from;
            dif.y = 0;
            Quaternion q = Quaternion.LookRotation(dif);
            transform.rotation = q;

            if (distance >= 5.0f)
            {
                status = "Chasing";
                CancelInvoke();
                agent.isStopped = false;
            }
        }
    }

    public void Shoot()
    {
        //Debug.Log("Shoot");
        GetComponent<AudioSource>().Play();
        Instantiate(shootpointFX, shootpoint.position, shootpoint.rotation);
        Vector3 to = player.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
        Vector3 from = shootpoint.position;
        Vector3 dif = to - from;
        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, dif, out hit))
        {
            Instantiate(impactpointFX, hit.point, shootpoint.rotation);
        }
        if (hit.collider.tag == "Player")
        {
            if ((player.GetComponent("PlayerControl") as PlayerControl) != null)
            {
                player.GetComponent<PlayerControl>().Damage();
            }
            else
            {
                player.GetComponent<ControlBD1>().Damage();
            }
            Invoke("Shoot", time);
        }
        else
        {
            Invoke("Shoot", 1.0f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Balas"))
        {
            status = "Dead";

            Vector3 lugar = player.transform.position + new Vector3(0, 1, 0); 
            Instantiate(Recompensa, lugar, Quaternion.identity);

            animator.SetTrigger("Dead");
            agent.isStopped = true;
            CancelInvoke();
            GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<PlayerControl>().EnemyKilled();
            SpawnPointEnemigos.ClonesRestantes = SpawnPointEnemigos.ClonesRestantes - 1;
        }
        if (collision.collider.CompareTag("Sable"))
        {
            status = "Dead";
            animator.SetTrigger("Dead");
            agent.isStopped = true;
            CancelInvoke();
            GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<ControlBD1>().EnemyKilled();
            SpawnPointEnemigos.ClonesRestantes = SpawnPointEnemigos.ClonesRestantes - 1;
        }
    }
}
//(gameObject.GetComponent("YourDesiredScript") as YourDesiredScript) != null