using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] float StartX, StartY,StartZ, EndX, EndY,EndZ;
    [SerializeField] float Stoptime;
    float time;
    float distance,speed=0;
    bool forward=true;
    Vector3 vec;
    Vector3 StartPos, EndPos;
    // Start is called before the first frame update
    void Start()
    {
        floor.transform.position=new Vector3 (StartX, StartY, StartZ);
        StartPos=new Vector3(StartX, StartY, StartZ);
        EndPos=new Vector3(EndX, EndY, EndZ);
        vec=EndPos-StartPos;
        distance = vec.magnitude;
        vec.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if(forward)
        {
            if ((floor.transform.position - StartPos).magnitude < distance / 4)
                speed += 0.003f;
            else if ((EndPos - floor.transform.position ).magnitude < distance / 4&&speed>0)
                speed -= 0.003f;
            floor.transform.Translate (vec*speed);
            if ((EndPos - floor.transform.position).magnitude < 0.1)
            {
                time += Time.deltaTime;
                if (time > Stoptime)
                    ChangeMode(false);
            }
        }
        else
        {
            if ((EndPos - floor.transform.position).magnitude < distance / 4)
            {
                speed += 0.003f;
            }
            else if ((floor.transform.position - StartPos).magnitude < distance / 4&&speed>0)
                speed -= 0.003f;
            floor.transform.Translate(-vec*speed);
            if ((StartPos - floor.transform.position).magnitude < 0.1)
            {
                time += Time.deltaTime;
                if (time > Stoptime)
                    ChangeMode(true);
            }

        }
    }
    public void ChangeMode(bool t)
    {
        forward = t;
        time = 0;
    }
}

