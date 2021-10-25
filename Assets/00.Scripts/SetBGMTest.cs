using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBGMTest : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip aClip;

    public void GazeClick()
    {
        aSource.clip = aClip;
        aSource.Stop();
        aSource.Play();
    }
}
