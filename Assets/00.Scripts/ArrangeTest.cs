using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class ArrangeTest : MonoBehaviour
{
    public float smoothTime = 5f;
    public float velocity = 0f;
    public PlayableDirector director;

    float initPos;
    CinemachineDollyCart cartScript;

    void Start()
    {
        cartScript = GetComponent<CinemachineDollyCart>();
        initPos = cartScript.m_Position;
    }

    public void Testbutton()
    {
        StartCoroutine("ArrangePlanets");
    }

    public void SetInitialPos()
    {
        cartScript.m_Position = Random.Range(0f, initPos);
        cartScript.m_Speed = -1f;
    }

    IEnumerator ArrangePlanets()
    {
        float startPos = cartScript.m_Position;
        while (cartScript.m_Position > 0.001f)
        {
            cartScript.m_Speed = 0f;
            cartScript.m_Position = Mathf.SmoothDamp(cartScript.m_Position, 0f,ref velocity, smoothTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}