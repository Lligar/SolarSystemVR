using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ResetManager : MonoBehaviour
{
    public InitialPosRot[] initObjects;
    public ObjectRotation earthRotScript;
    public PlayableDirector director;
    public GameObject mainCamera;
    public GameObject backToPlanet;
    public void ResetObjects()
    {
        mainCamera.transform.position = new Vector3(0, 0, 0);
        mainCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
        
        if (earthRotScript.enabled)
        {
            earthRotScript.enabled = false;
        }

        for (int i = 0; i < initObjects.Length; i++)
        {
            if (!initObjects[i].gameObject.activeInHierarchy)
            {
                initObjects[i].gameObject.SetActive(true);
            }
            initObjects[i].ResetPosRot();
            backToPlanet.SetActive(true);
            director.Play();
        }
    }

}
