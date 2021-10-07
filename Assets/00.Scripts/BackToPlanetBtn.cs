using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPlanetBtn : MonoBehaviour
{
    public GameObject fadeManager;

    public void GazeClick()
    {
        fadeManager.tag = "BackToPlanets";
        fadeManager.GetComponent<FadeScreen>().buttonClicked = true;
        gameObject.SetActive(false);
    }
}
