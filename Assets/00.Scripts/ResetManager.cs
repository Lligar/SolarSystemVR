using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ResetManager : MonoBehaviour
{
    public InitialPosRot[] initObjects;
    public ObjectRotation earthRot;
    public PlayableDirector director;
    public void ResetObjects()
    {
        earthRot.enabled = false;
        for (int i = 0; i < initObjects.Length; i++)
        {
            initObjects[i].ResetPosRot();
            director.Play();
        }
    }

}
