using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioEffect : MonoBehaviour
{
    public Material talkMat;
    public Material idleMat;
    public SkinnedMeshRenderer applyMat;

    bool testbool = true;
    float testfloat = 0.5f;
    float testtimer;

    void Start()
    {
        StartCoroutine("TestCor");
    }

    void Update()
    {
        if(testbool)
        {
            testtimer += Time.deltaTime;
            if (testtimer >= testfloat)
            {
                testbool = false;
                StartCoroutine("Bleep");
            }
        }
    }

    IEnumerator Bleep()
    {
        testtimer = 0f;
        testfloat = Random.Range(0.1f, 0.5f);
        applyMat.material.color = new Color(0.25f, 1f, 0.25f);
        yield return new WaitForSeconds(Random.Range(0.2f, 0.4f));
        applyMat.material.color = new Color(1f, 1f, 1f);
        testbool = true;
    }

    IEnumerator TestCor()
    {
        yield return new WaitForSeconds(5f);
        applyMat.material = talkMat;
    }
}
