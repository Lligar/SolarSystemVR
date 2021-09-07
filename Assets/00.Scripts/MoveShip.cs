using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed;
    public MeshRenderer glassMat;
    public float fadeFloat;


    void Start()
    {
        
    }

    void Update()
    {
        if(speed <= 5f)
        {
            speed += Time.deltaTime * 2.5f;
            if(speed >= 0f)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            fadeFloat += 0.005f;
            glassMat.material.color = new Vector4(0f, 0f, 0f, fadeFloat);
        }
    }
}
