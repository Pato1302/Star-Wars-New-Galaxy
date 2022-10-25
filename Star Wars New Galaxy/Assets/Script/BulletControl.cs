using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject impactFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Instantiate(impactFX, transform.position, transform.rotation);
    }
}
