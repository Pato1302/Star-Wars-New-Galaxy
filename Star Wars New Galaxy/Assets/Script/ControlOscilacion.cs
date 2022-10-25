using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOscilacion : MonoBehaviour
{
    Vector3 original;
    float theta;
    public float speed = 1;
    public float altura = 1;
    // Start is called before the first frame update
    void Start()
    {
        original=transform.position;
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nueva = original;
        nueva.y = original.y + Mathf.Sin(theta)*altura;
        theta = theta + Time.deltaTime*speed;
        transform.position = nueva;
    }
}
