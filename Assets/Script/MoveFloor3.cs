using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveFloor3 : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] float StartX, StartY, StartZ, EndX, EndY, EndZ;
    float x, y, z;
    float time,time2;
    float distance, speed = 0;
    Vector3 vec;
    Vector3 StartPos, EndPos;
    bool flag=false;
    bool moving = false;
    bool check=true;
    //----音----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference floormove;
    bool sound;
    //----------

    CameraCon cameracon;
    camera_ch camera_ch;

    // Start is called before the first frame update
    void Start()
    {
        floor.transform.position = new Vector3(StartX, StartY, StartZ);
        StartPos = new Vector3(StartX, StartY, StartZ);
        EndPos = new Vector3(EndX, EndY, EndZ);
        vec = EndPos - StartPos;
        distance = vec.magnitude;
        vec.Normalize();
        sound = true;
        cameracon = GameObject.Find("CameraCon").GetComponent<CameraCon>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving)
        {

            Invoke("Change", 4.0f);
            if (Move() == true)
            {
                moving = false;
                ReturnMode();
            }
        }
    }

    void Update()
    {
        if(cameracon.sanji)
            camera_ch = GameObject.Find("MainCamera").GetComponent<camera_ch>();
        else
            camera_ch = GameObject.Find("2DCamera").GetComponent<camera_ch>();

        Debug.Log(check && camera_ch.Hukan);
        if (Input.GetButtonDown("Change") && check&&camera_ch.Hukan==false)
        {
            check= false;
            time2 = 0;
            Invoke("switching", 2.0f);
        }
        if (check == false)
        {
            time2 += Time.deltaTime;
            if(time2 > 4.5)
            {
                check = true;
            }
        }
    }

    public void ReturnMode()
    {
        x = StartX;
        y = StartY;
        z = StartZ;
        StartX = EndX;
        StartY = EndY;
        StartZ = EndZ;
        EndX = x;
        EndY = y;
        EndZ = z;
        StartPos = new Vector3(StartX, StartY, StartZ);
        EndPos = new Vector3(EndX, EndY, EndZ);
        vec = EndPos - StartPos;
        distance = vec.magnitude;
        vec.Normalize();
    }
    public bool Move()
    {
        if ((floor.transform.position - StartPos).magnitude < distance / 3)
            speed += 110f * Time.deltaTime;
        else if ((EndPos - floor.transform.position).magnitude < 0.5)
        {
            speed = 0;
            return true;
        }
        floor.transform.Translate(vec * speed * Time.deltaTime);
        return false;

    }
    public void Change()
    {
        flag = false;
    }

    public void switching()
    {
        ADXSoundManager.Instance.PlaySound("flmove", floormove.AcbAsset.Handle, floormove.CueId, gameObject.transform, false);
        flag = true;
        moving = true;
    }
}
