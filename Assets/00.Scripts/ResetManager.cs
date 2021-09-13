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
    public GameObject planetSelection;

    public void ResetObjects()
    {
        mainCamera.transform.position = new Vector3(0, 0, 0);
        mainCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
        backToPlanet.SetActive(false);
        planetSelection.SetActive(true);

        for (int i = 0; i < initObjects.Length; i++)
        {
            if(!initObjects[i].gameObject.activeSelf)
            {
                initObjects[i].gameObject.SetActive(true);
            }
            print(initObjects[i].gameObject + " + " + initObjects[i].initPos + " + " + initObjects[i].initRot);
            initObjects[i].ResetPosRot();
            
        }

        if (earthRotScript.enabled)
        {
            earthRotScript.enabled = false;
        }
    }
}
