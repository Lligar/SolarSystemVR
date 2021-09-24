using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    float prev;
    float current;
    private void Update()
    {
        prev = current;
        current = transform.eulerAngles.y;
        float velocity = (Mathf.Abs(prev) - Mathf.Abs(current) * Time.deltaTime);
        print(velocity);
    }
}
