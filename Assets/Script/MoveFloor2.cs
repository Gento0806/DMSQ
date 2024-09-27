using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFloor2 : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] float StartX, StartY, StartZ, EndX, EndY, EndZ;
    [SerializeField] float Stoptime;
    float time;
    float distance, speed = 0;
    bool forward = false;
    Vector3 vec;
    Vector3 StartPos, EndPos;

    //----音----
    [SerializeField]
    CriWare.Assets.CriAtomCueReference floormove;
    bool sound;
    //----------


    public bool ReturunFlag;//元の場所に戻したい場合
    bool Return = false;

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
    void Update()
    {
        if (cameracon.sanji)
            camera_ch = GameObject.Find("MainCamera").GetComponent<camera_ch>();
        else
            camera_ch = GameObject.Find("2DCamera").GetComponent<camera_ch>();

        if (Input.GetButtonDown("Change") && !camera_ch.Hukan)
        {
            ChangeMode();
            if (ReturunFlag)
            {
                Return = true;
            }
        }
        if (forward)
        {
            if (sound)
            {
                ADXSoundManager.Instance.PlaySound("flmove", floormove.AcbAsset.Handle, floormove.CueId, gameObject.transform, false);
                sound = false;
            }
            if ((floor.transform.position - StartPos).magnitude < distance / 3)
                speed += 110f * Time.deltaTime;
            else if ((EndPos - floor.transform.position).magnitude < 0.5)
                speed = 0;
            floor.transform.Translate(vec * speed*Time.deltaTime);
        }

       /* if(floor.transform.position == new Vector3(EndX, EndY, EndZ))
        {
            forward = false;
            if (Return)
            {
                ReturnMode();
                ChangeMode();
                Return = false;
            }
        }*/

    }
    public void ChangeMode()
    {
        forward = true;
    }

    public void ReturnMode()
    {

        StartX = EndX;
        StartY = EndY;
        StartZ = EndZ;
        EndX = StartX;
        EndY = StartY;
        EndZ = StartZ;

    }
}
