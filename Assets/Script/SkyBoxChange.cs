using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;
using UnityEngine.SceneManagement;

public class SkyBoxChange : MonoBehaviour
{

    //スカイボックス
    public Material skyboxMaterial;
    public Color startColor = Color.HSVToRGB(82f, 49f, 60f);
    public Color endColor = Color.HSVToRGB(98f, 164f, 209f);
    public Color MatStartColor = Color.HSVToRGB(231f, 52f, 52f);
    public Color MatEndColor = Color.HSVToRGB(86f, 255f, 244f);
    public Color EmiStartColor = Color.HSVToRGB(231f, 52f, 52f);
    public Color EmiEndColor = Color.HSVToRGB(86f, 255f, 244f);
    public Color WallStartColor = Color.HSVToRGB(231f, 52f, 52f);
    public Color WallEndColor = Color.HSVToRGB(86f, 255f, 244f);
    //public float duration = 5.0f;
    public float tImer = 0;
    public float t;
    public Material[] Mat = new Material[9];
    public Material Wall;

    //----音----
    public enum move_type
    {
        move,
        idle
    }
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference2;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference3;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference goal;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference hover;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference clear;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference soner;
    bool ismovestart = true;
    [SerializeField] private move_type moveplayer;
    move_type currentstate = move_type.idle;
    move_type transit = move_type.idle;
    bool first_hover = true;
    Vector3 vec;
    //----------
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        t = 1f;
        foreach (Material material in Mat)
        {
            material.SetColor("_BaseColor", MatStartColor);
            material.SetColor("_EmissionColor", EmiStartColor);
        }

        skyboxMaterial.SetColor("_Tint", startColor);
        Wall.SetColor("_BaseColor", WallStartColor);
        Wall.SetColor("_EmissionColor", EmiStartColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkyBoxChangePlay()
    {
        // Timerを更新
        tImer += 1 * Time.deltaTime;
        float TIMER = tImer / t; 
        // 色を線形補間して設定
        Color currentColor = Color.Lerp(startColor, endColor, TIMER);
        skyboxMaterial.SetColor("_Tint", currentColor);
        Color currentColor2 = Color.Lerp(MatStartColor, MatEndColor, TIMER);
        Color EmiColor2 = Color.Lerp(EmiStartColor, EmiEndColor, TIMER);
        Color currentColor3 = Color.Lerp(WallStartColor, WallEndColor, TIMER);
        foreach (Material material in Mat)
        {
            material.SetColor("_BaseColor", currentColor2);
            material.SetColor("_EmissionColor", EmiColor2);
        }
        Wall.SetColor("_BaseColor", currentColor3);
        Wall.SetColor("_EmissionColor", EmiColor2);


        if (tImer >= t)
        {
            CriAtomEx.ApplyDspBusSnapshot("Snapshot", 100);
            ADXSoundManager.Instance.StopSound("move");
            ADXSoundManager.Instance.StopSound("hover");
            ADXSoundManager.Instance.StopSound("bgm");
            ADXSoundManager.Instance.StopSound("soner");
            ADXSoundManager.Instance.PlaySound("goal", goal.AcbAsset.Handle, goal.CueId, gameObject.transform, false);
            SceneSelect.StageNumChange();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Next");
        }
    }
}
