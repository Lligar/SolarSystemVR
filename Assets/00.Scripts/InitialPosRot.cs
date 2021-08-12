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
    }
}
