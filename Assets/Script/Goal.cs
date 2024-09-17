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
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        moveplayer2D = GameObject.Find("mashiro_2model").GetComponent<Move_Player>();
        moveplayer3D = GameObject.Find("mashiro_3model").GetComponent<Move_Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveplayer2D.SkyBoxChangeBool || moveplayer3D.SkyBoxChangeBool)
        {
            tImer2D = moveplayer2D.tImer;
            tImer3D = moveplayer3D.tImer;
            animator.SetBool("goal", true);
            

            if (tImer2D>=moveplayer2D.t-1f || tImer3D>=moveplayer3D.t-1f)
            {
                animator.SetBool("goal", false);
                animator.SetBool("end", true);
            }
        }
        
    }
}
