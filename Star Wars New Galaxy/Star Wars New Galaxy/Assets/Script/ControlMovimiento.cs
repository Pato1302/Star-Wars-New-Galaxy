using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovimiento : MonoBehaviour
{
    public Vector3 metrosPorSegundo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + metrosPorSegundo * Time.deltaTime;
    }
}
