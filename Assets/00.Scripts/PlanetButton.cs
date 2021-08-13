using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlanetButton : MonoBehaviour
{
    public PlayableDirector director;
    public PlayableAsset playableAsset;
    void GazeClick()
    {
        director.playableAsset = playableAsset;
        director.Play();
    }
}
