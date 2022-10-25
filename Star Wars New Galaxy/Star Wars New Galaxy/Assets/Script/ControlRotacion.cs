using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRotacion : MonoBehaviour
{
    public float gradosPorSegundo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotar         x        y                            z
        transform.Rotate(0, gradosPorSegundo * Time.deltaTime, 0);
    }
}
