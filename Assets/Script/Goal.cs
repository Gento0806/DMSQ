using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Goal : MonoBehaviour
{
    Animator animator;
    Move_Player moveplayer2D;
    Move_Player moveplayer3D;
    float tImer2D;
    float tImer3D;
    Rigidbody sanjiRB;
    Rigidbody nijiRB;
    CameraCon cameracon;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameracon = GameObject.Find("CameraCon").GetComponent<CameraCon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameracon.sanji)
        {
            moveplayer3D = GameObject.Find("mashiro_3model").GetComponent<Move_Player>();
            sanjiRB = GameObject.Find("mashiro_3model").GetComponent<Rigidbody>();
            if (moveplayer3D.SkyBoxChangeBool)
            {
                tImer3D = moveplayer3D.tImer;
                animator.SetBool("goal", true);


                if (tImer3D >= moveplayer3D.t - 1f)
                {
                    animator.SetBool("goal", false);
                    animator.SetBool("end", true);
                }
            }
        }
        else
        {
            moveplayer2D = GameObject.Find("mashiro_2model").GetComponent<Move_Player>();
            nijiRB = GameObject.Find("mashiro_2model").GetComponent<Rigidbody>();
            if (moveplayer2D.SkyBoxChangeBool)
            {
                tImer2D = moveplayer2D.tImer;
                animator.SetBool("goal", true);


                if (tImer2D >= moveplayer2D.t - 1f)
                {
                    animator.SetBool("goal", false);
                    animator.SetBool("end", true);
                }
            }
        }

        
        
    }
}
