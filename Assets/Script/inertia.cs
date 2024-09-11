using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ineartia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Movefloor")
        {
            this.gameObject.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.transform.parent = null;
    }
}
