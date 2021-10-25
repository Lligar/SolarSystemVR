using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGMManager : MonoBehaviour
{
    AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();    
    }

    public void playBGM()
    {
        StartCoroutine("IncreaseBGM");
    }

    IEnumerator IncreaseBGM()
    {
        aSource.Play();
        while(aSource.volume < 1f)
        {
            aSource.volume += 0.0005f;
            yield return null;
        }
    }
}
