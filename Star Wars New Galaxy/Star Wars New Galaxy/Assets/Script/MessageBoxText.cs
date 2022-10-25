using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxText : MonoBehaviour
{
    public string message;
    public float seconds;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textBox.text = message;
            Invoke("DeleteText", seconds);
        }
    }
    public void DeleteText()
    {
        textBox.text = "";
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
