using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour
{
    public PlayableDirector director;
    public PlayableAsset playableAsset;
    public GameObject lightRig;
    public Image fadeImage;
    void GazeClick()
    {
        director.playableAsset = playableAsset;
        director.Play();
        if (gameObject.name == "PanelMoon")
        {
            lightRig.transform.GetChild(0).gameObject.SetActive(true);
            lightRig.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        print(fadeImage.color.a);
        if (fadeImage.color.a > 0f)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
