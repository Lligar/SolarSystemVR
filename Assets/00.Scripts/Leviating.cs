using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leviating: MonoBehaviour
{
    public Transform dialogPanel;
    public Transform UICanvas;

    public float timer;
    public float speed;
    public float targetPos = 0.03f;
    public float targetPosDif;
    bool trigger;

    void Update()
    {
        timer += Time.deltaTime * speed;
        if (timer >= speed)
        {
            if (trigger)
            {
                trigger = false;
                timer = 0f;
            }
            else
            {
                trigger = true;
                timer = 0f;
            }
        }

        if (trigger)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, targetPos, timer), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, targetPos - targetPosDif, timer), transform.localPosition.z);
        }
    }
}
