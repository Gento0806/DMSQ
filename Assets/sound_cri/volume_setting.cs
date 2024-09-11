using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume_setting : MonoBehaviour
{
    private static float bgmVolume;
    private static float seVolume;
    static float previousbgmVolume;
    static float previousseVolume;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    static bool playing = false;

    void Start()
    {
        if (playing)
        {
            bgmSlider.value = bgmVolume;
            seSlider.value = seVolume;
        }
        playing = true;
    }

    void Update()
    {

        // �X���C�_�[�̒l���󂯎��
        bgmVolume = bgmSlider.value;
        seVolume = seSlider.value;

        if (bgmVolume != previousbgmVolume || seVolume != previousseVolume)
        {
            // �J�e�S���̉��ʂ�ύX����
            ADXSoundManager.Instance.SetCategoryVolume("BGM", bgmVolume);
            ADXSoundManager.Instance.SetCategoryVolume("SE", seVolume);
            previousbgmVolume = bgmVolume;
            previousseVolume= seVolume;
        }

    }
}
