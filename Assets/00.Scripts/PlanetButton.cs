using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour
{
    public CameraFadeRig camFade;
    public PlayableDirector director;
    public PlayableAsset playableAsset;
    public GameObject lightRig;
    public Image fadeImage;
    void GazeClick()
    {
        camFade.buttonClicked = true;
        director.playableAsset = playableAsset;
        if (gameObject.name == "PanelMoon" || gameObject.name == "PanelEarth")
        {
            lightRig.transform.GetChild(0).gameObject.SetActive(true);
            lightRig.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (fadeImage.color.a > 0f)
        {
            GetComponent<BoxCollider>().enabled = false;
            transform.parent.GetComponent<GraphicRaycaster>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
            transform.parent.GetComponent<GraphicRaycaster>().enabled = true;
        }
    }
}
