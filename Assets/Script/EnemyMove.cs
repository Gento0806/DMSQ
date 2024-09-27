using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float EnemyMoveSpeed;
    public bool sanji;
    float LiveTime = 0;
    GameObject cameracon;
    Rigidbody Enemyrigid;
    GameObject System;

    
    void Start()
    {
        Enemyrigid = this.GetComponent<Rigidbody>();
        cameracon=GameObject.Find("CameraCon");
        System = GameObject.Find("System");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        this.transform.position += this.transform.forward * EnemyMoveSpeed * Time.deltaTime;
        LiveTime += Time.deltaTime;
        if (LiveTime > 30 || (sanji && System.GetComponent<Sisutemu>().DeathLine3D > this.transform.position.y) || (sanji == false && (System.GetComponent<Sisutemu>().DeathLine2D > this.transform.position.y) || 600 < this.transform.position.y))
        {
            Destroy(this.gameObject);
        }
        Debug.Log(cameracon.GetComponent<CameraCon>().sanji);
        if (sanji)
        {
            if (cameracon.GetComponent<CameraCon>().sanji == true)
            {
                Enemyrigid.AddForce(new Vector3(0, -30f, 0));
            }
            else
            {
                Enemyrigid.AddForce(new Vector3(30f, 0, 0));
            }
        }
        else
        {
            if (cameracon.GetComponent<CameraCon>().sanji == true)
            {

            }
            else
            {
                Enemyrigid.AddForce(0, -30f, 0);
            }
        }
        /*
        if (Physics.Raycast(ray, out hit))
        {
            if (Vector3.Distance(hit.point, this.transform.position) < 2)
            {
                this.transform.eulerAngles = -this.transform.forward;
            }
        }*/
    }
}
