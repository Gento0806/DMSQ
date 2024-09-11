using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraroteto : MonoBehaviour
{
    [SerializeField] GameObject centerObj;
    int angle = 90;
    public int nowangle = 0;

    //----��----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    //----------
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RotateAround(���S�̏ꏊ,��]��,��]�p�x)
            transform.RotateAround(centerObj.transform.position, Vector3.up, angle);
            nowangle += angle;

            
            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //RotateAround(���S�̏ꏊ,��]��,��]�p�x)
            transform.RotateAround(centerObj.transform.position, Vector3.up, -angle);
            nowangle -= angle;
        }
        if (nowangle == 360)
        {
            nowangle = 0;
        }
        if (nowangle < 0)
        {
            nowangle = 270;
        }
       // this.transform.LookAt(centerObj.transform);



    }
}
