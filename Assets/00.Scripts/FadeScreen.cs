using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public Image fadeImage;
    public Renderer reticlePointer;
    public ResetManager resetManager;
    public bool buttonClicked;
    public SphereCollider earthCollider;

    float fadeAlpha;
    bool fadeOut;

    void GazeClick()
    {
        buttonClicked = true;
    }

    void FadeAction()
    {
        if(gameObject.tag == "StartButton")
        {
            SceneManager.LoadScene(1);
        }
        if(gameObject.tag == "BackToPlanets")
        {
            resetManager.ResetObjects();
            if(earthCollider)
            {
                earthCollider.enabled = false;
            }    
        }
    }

    void Update()
    {
        if(buttonClicked)
        {
            if (!fadeOut)
            {
                fadeAlpha += 0.5f * Time.deltaTime;
                fadeImage.color = new Vector4(0f, 0f, 0f, fadeAlpha);
                reticlePointer.material.color = new Vector4 (255f, 255f, 255f, 1f - fadeAlpha);
                if(fadeAlpha >= 1.5f)
                {
                    FadeAction();
                    fadeOut = true;
                }
            }
            else
            {
                fadeAlpha -= 0.5f * Time.deltaTime;
                fadeImage.color = new Vector4(0f, 0f, 0f, fadeAlpha);
                reticlePointer.material.color = new Vector4(255f, 255f, 255f, 1f - fadeAlpha);
                if (fadeAlpha <= 0f)
                {
                    buttonClicked = false;
                    fadeOut = false;
                }
            }
        }
    }
}
