using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPosRot : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot;
    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }

    public void ResetPosRot()
    {
        gameObject.transform.position = initPos;
        gameObject.transform.rotation = initRot;
        if (gameObject.name == "LightRig")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
