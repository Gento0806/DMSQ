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
        // transform���擾
        Transform myTransform = other.transform;

        // ���W���擾
        Vector3 pos = myTransform.position;

        // ���݈ʒu�擾
        var position = transform.position;

        Force += AddForce*Time.deltaTime;
        // ���݂̍��W�����xyz ��1�����Z���Ĉړ�
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
