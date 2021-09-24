using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    SpriteRenderer image;
    float timer;
    private void OnEnable()
    {
        image = GetComponent<SpriteRenderer>();
        image.enabled = false;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            timer = 0f;
            if(image.enabled)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
        }
    }
    private void OnDisable()
    {
        image.enabled = true;
        timer = 0f;
    }
}
