using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
    }
}
