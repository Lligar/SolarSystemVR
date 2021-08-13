using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestScript : MonoBehaviour
{
    public InitialPosRot[] initObjects;
    public ObjectRotation earthRot;
    public PlayableDirector director;
    public GameObject mainCamera;
    public void tester()
    {
        mainCamera.transform.position = new Vector3(0, 0, 0);
        mainCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
        earthRot.enabled = false;

        for (int i = 0; i < initObjects.Length; i++)
        {
            if (!initObjects[i].gameObject.activeInHierarchy)
            {
                initObjects[i].gameObject.SetActive(true);
            }
            initObjects[i].ResetPosRot();
            director.Play();
        }
    }
}
