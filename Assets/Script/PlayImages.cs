using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayImages : MonoBehaviour
{
    private Image image;
    private CameraCon cameracon;

    public Sprite Jump3D;
    public Sprite Hukan3D;
    public Sprite Change3D;
    public Sprite L_Camera3D;
    public Sprite R_Camera3D;
    public Sprite Neutral3D;

    public Sprite Jump2D;
    public Sprite Hukan2D;
    public Sprite Change2D;
    public Sprite Neutral2D;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        cameracon = GameObject.Find("CameraCon").GetComponent<CameraCon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameracon.sanji)
        {
            if (Input.GetButton("Jump")) image.sprite = Jump3D;
            else if (Input.GetButton("Hukan")) image.sprite = Hukan3D;
            else if (Input.GetButton("Change")) image.sprite = Change3D;
            else if (Input.GetButton("KirikaeLeft")) image.sprite = L_Camera3D;
            else if (Input.GetButton("KirikaeRight")) image.sprite = R_Camera3D;
            else image.sprite = Neutral3D;
        }
        else
        {
            if (Input.GetButton("Jump")) image.sprite = Jump2D;
            else if (Input.GetButton("Hukan")) image.sprite = Hukan2D;
            else if (Input.GetButton("Change")) image.sprite = Change2D;
            else image.sprite = Neutral2D;
        }
        
    }
}
