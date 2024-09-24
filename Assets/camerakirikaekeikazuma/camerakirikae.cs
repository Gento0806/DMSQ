using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class camerakirikae : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public PlayableDirector playableDirector2;
    int simama = 0;
    int jikannkasegisima = 0;
    bool jikannkann = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && simama == 0 && jikannkasegisima == 0)
        {
            playableDirector.Play();
            simama++;
            jikannkann = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && simama > 0 && jikannkasegisima == 10)
        {
            playableDirector2.Play();
            simama = 0;
            jikannkann = false;
        }

        if (jikannkann == true)
        {
            if (jikannkasegisima < 10)
            {
                jikannkasegisima++;
            }
        }
        else
        {
            if (jikannkasegisima > 0)
            {
                jikannkasegisima--;
            }


        }
    }
}
