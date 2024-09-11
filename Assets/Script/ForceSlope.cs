using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSlope : MonoBehaviour
{
    [SerializeField] Vector3 AddForce;
    Vector3 Force;
    // Start is called before the first frame update
    void Start()
    {
        Force = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        // transform‚ğæ“¾
        Transform myTransform = other.transform;

        // À•W‚ğæ“¾
        Vector3 pos = myTransform.position;

        // Œ»İˆÊ’uæ“¾
        var position = transform.position;

        Force += AddForce*Time.deltaTime;
        // Œ»İ‚ÌÀ•W‚©‚ç‚Ìxyz ‚ğ1‚¸‚Â‰ÁZ‚µ‚ÄˆÚ“®
        myTransform.Translate(Force, Space.World);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Force= Vector3.zero;
        }
    }
}
