using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CameraFadeRig : MonoBehaviour
{
    public PlayableDirector director;
    public bool buttonClicked;
    public Image fadeImage;
    public GameObject sun;
    public GameObject earthAndMoon;

    float fadeAlpha;
    bool fadeOut;

    void Start()
    {
        
    }

    void Update()
    {
        if (buttonClicked)
        {
            if (!fadeOut)
            {
                fadeAlpha += 0.5f * Time.deltaTime;
                fadeImage.color = new Vector4(0f, 0f, 0f, fadeAlpha);
                if (fadeAlpha >= 1.5f)
                {
                    FadeAction();
                    fadeOut = true;
                }
            }
            else
            {
                fadeAlpha -= 0.5f * Time.deltaTime;
                fadeImage.color = new Vector4(0f, 0f, 0f, fadeAlpha);
                if (fadeAlpha <= 0f)
                {
                    buttonClicked = false;
                    fadeOut = false;
                }
            }
        }
    }

    void FadeAction()
    {
        if(director.playableAsset.name == "EarthTimeline" || director.playableAsset.name == "MoonTimeline")
        {
            sun.SetActive(false);
        }
        if(director.playableAsset.name == "SunTimeline")
        {
            earthAndMoon.SetActive(false);
        }
        director.Play();
    }

    public void MoonCamSig()
    {
        director.time = 6.9f;
    }
    
    public void SolarSysSig()
    {
        director.Pause();
        buttonClicked = true;
    }
}
