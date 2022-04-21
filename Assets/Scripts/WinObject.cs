using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("PickUp"))
        {
            gameObject.SetActive(false);
            winTextObject.SetActive(true);
        }      
    }
}
