using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed;
    public MeshRenderer glassMat;
    public Transform background;
    public DialogManager diaManager;
    public float fadeFloat = 0.9f;
    public GameObject respawn;

    void Start()
    {
        
    }

    void Update()
    {
        if(speed >= -10f)
        {
            speed -= Time.deltaTime * 2.5f;
            if(speed <= 0f)
            {
                background.position += transform.forward * Time.deltaTime * speed;
            }
        }
        else
        {
            background.position += transform.forward * Time.deltaTime * speed;
            fadeFloat += 0.005f;
            glassMat.material.color = new Vector4(glassMat.material.color.r, glassMat.material.color.g, glassMat.material.color.b, fadeFloat);
            if(glassMat.material.color.a >= 1f)
            {
                diaManager.StartCoroutine("ArriveSpace");
                respawn.SetActive(true);
            }
        }
    }
}
