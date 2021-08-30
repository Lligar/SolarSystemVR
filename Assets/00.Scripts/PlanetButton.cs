using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlanetButton : MonoBehaviour
{
    public PlayableDirector director;
    public PlayableAsset playableAsset;
    public GameObject lightRig;
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
}
