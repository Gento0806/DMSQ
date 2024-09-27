using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // ‰ñ“]‘¬“x‚ğ’²®‚Å‚«‚é‚æ‚¤‚É‚·‚é
    public float rotationSpeed = 100f;

    void Update()
    {
        // IƒL[‚ª‰Ÿ‚³‚ê‚Ä‚¢‚éŠÔ
        if (Input.GetKey(KeyCode.I))
        {
            // Y²‚Å•‰‚Ì•ûŒü‚É‰ñ“]
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.O))
        {
            // Y²‚Å•‰‚Ì•ûŒü‚É‰ñ“]
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
