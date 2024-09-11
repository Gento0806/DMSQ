using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    Rigidbody rb;
    int dir = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            dir = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = 2;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = 3;
        }

        switch (dir)//èdóÕï˚å¸ÇÃêÿÇËë÷Ç¶
        {
            case 0:
                rb.AddForce(0,-9.8f,0, ForceMode.Acceleration);
                if (rb.velocity.y < 0)
                {
                    rb.AddForce(0, -1, 0,ForceMode.Impulse);
                }
                break;
            case 1:
                rb.AddForce(0, 0, 9.8f, ForceMode.Acceleration);
                if (rb.velocity.y < 0)
                {
                    rb.AddForce(0, 0, 1, ForceMode.Impulse);
                }
                break;
            case 2:
                rb.AddForce(0, 9.8f, 0, ForceMode.Acceleration);
                if (rb.velocity.y < 0)
                {
                    rb.AddForce(0, 1, 0, ForceMode.Impulse);
                }
                break;
            case 3:
                rb.AddForce(0, 0, -9.8f, ForceMode.Acceleration);
                if (rb.velocity.y < 0)
                {
                    rb.AddForce(0, 0, -1, ForceMode.Impulse);
                }
                break;
        }
    }
}
