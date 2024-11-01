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
        // transformを取得
        Transform myTransform = other.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        // 現在位置取得
        var position = transform.position;

        Force += AddForce*Time.deltaTime;
        // 現在の座標からのxyz を1ずつ加算して移動
        myTransform.Translate(Force, Space.World);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Force= Vector3.zero;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }
}
