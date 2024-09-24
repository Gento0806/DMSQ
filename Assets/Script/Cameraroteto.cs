using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraroteto : MonoBehaviour
{
    [SerializeField] GameObject centerObj;
    int angle = 90;
    public int nowangle = 0;

    //----‰¹----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    //----------
    void Update()
    {
        if (Input.GetButtonDown("KirikaeLeft"))
        {
            //RotateAround(’†S‚ÌêŠ,‰ñ“]²,‰ñ“]Šp“x)
            transform.RotateAround(centerObj.transform.position, Vector3.up, angle);
            nowangle += angle;

            
            
        }
        else if (Input.GetButtonDown("KirikaeRight"))
        {
            //RotateAround(’†S‚ÌêŠ,‰ñ“]²,‰ñ“]Šp“x)
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
