using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDirectionCanvas : MonoBehaviour
{
    public Transform lightRig;

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lightRig.rotation.eulerAngles.y);
    }
}
