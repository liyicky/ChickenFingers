using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EndZone")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            this.gameObject.SetActive(false);
        }
    }
}
