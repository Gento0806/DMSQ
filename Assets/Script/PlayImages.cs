using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayImages : MonoBehaviour
{
    private Image image;
    private CameraCon cameracon;
    private camera_ch camerach;

    //3D
    public Sprite Jump3D;
    public Sprite Hukan3D;
    public Sprite Change3D;
    public Sprite L_Camera3D;
    public Sprite R_Camera3D;
    public Sprite Neutral3D;

    public Sprite KeyBoardJump3D;
    public Sprite KeyBoardHukan3D;
    public Sprite KeyBoardChange3D;
    public Sprite KeyBoardL_Camera3D;
    public Sprite KeyBoardR_Camera3D;
    public Sprite KeyBoardNeutral3D;
    //лбХ
    public Sprite L_CameraHukan;
    public Sprite R_CameraHukan;
    public Sprite NeutralHukan;
    public Sprite NeutralHukan2D;

    public Sprite KeyBoardL_CameraHukan;
    public Sprite KeyBoardR_CameraHukan;
    public Sprite KeyBoardNeutralHukan;
    public Sprite KeyBoardNeutralHukan2D;
    //2D
    public Sprite Jump2D;
    public Sprite Hukan2D;
    public Sprite Change2D;
    public Sprite Neutral2D;

    public Sprite KeyBoardJump2D;
    public Sprite KeyBoardHukan2D;
    public Sprite KeyBoardChange2D;
    public Sprite KeyBoardNeutral2D;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        cameracon = GameObject.Find("CameraCon").GetComponent<CameraCon>();
    }
    // Update is called once per frame
    string[] controller;
    void Update()
    {
        string[] controllers = Input.GetJoystickNames();

        if (controllers.Length > 0 && !string.IsNullOrEmpty(controllers[0]))
        {
            if (cameracon.sanji)
            {
                camerach = GameObject.Find("MainCamera").GetComponent<camera_ch>();
                if (!camerach.Hukan)
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
                    if (Input.GetButton("KirikaeLeft")) image.sprite = L_CameraHukan;
                    else if (Input.GetButton("KirikaeRight")) image.sprite = R_CameraHukan;
                    else image.sprite = NeutralHukan;
                }

            }
            else
            {
                camerach = GameObject.Find("2DCamera").GetComponent<camera_ch>();
                if (!camerach.Hukan)
                {
                    if (Input.GetButton("Jump")) image.sprite = Jump2D;
                    else if (Input.GetButton("Hukan")) image.sprite = Hukan2D;
                    else if (Input.GetButton("Change")) image.sprite = Change2D;
                    else image.sprite = Neutral2D;
                }
                else
                {
                    image.sprite = NeutralHukan2D;
                }

            }
        }
        else
        {
            if (cameracon.sanji)
            {
                camerach = GameObject.Find("MainCamera").GetComponent<camera_ch>();
                if (!camerach.Hukan)
                {
                    if (Input.GetButton("Jump")) image.sprite = KeyBoardJump3D;
                    else if (Input.GetButton("Hukan")) image.sprite = KeyBoardHukan3D;
                    else if (Input.GetButton("Change")) image.sprite = KeyBoardChange3D;
                    else if (Input.GetButton("KirikaeLeft")) image.sprite = KeyBoardL_Camera3D;
                    else if (Input.GetButton("KirikaeRight")) image.sprite = KeyBoardR_Camera3D;
                    else image.sprite = KeyBoardNeutral3D;
                }
                else
                {
                    if (Input.GetButton("KirikaeLeft")) image.sprite = KeyBoardL_CameraHukan;
                    else if (Input.GetButton("KirikaeRight")) image.sprite = KeyBoardR_CameraHukan;
                    else image.sprite = KeyBoardNeutralHukan;
                }

            }
            else
            {
                camerach = GameObject.Find("2DCamera").GetComponent<camera_ch>();
                if (!camerach.Hukan)
                {
                    if (Input.GetButton("Jump")) image.sprite = KeyBoardJump2D;
                    else if (Input.GetButton("Hukan")) image.sprite = KeyBoardHukan2D;
                    else if (Input.GetButton("Change")) image.sprite = KeyBoardChange2D;
                    else image.sprite = KeyBoardNeutral2D;
                }
                else
                {
                    image.sprite = KeyBoardNeutralHukan2D;
                }

            }
        }
        
    }
}
