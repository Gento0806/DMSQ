using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RollOptionImage : MonoBehaviour
{
    public GameObject optionbutton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject selectedobject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectedobject);
        Debug.Log(optionbutton);
        if (selectedobject == optionbutton)
        {
            
            Debug.Log("true");
            optionbutton.transform.Rotate(0, 0, 60f*Time.deltaTime);
        }
    }
}
