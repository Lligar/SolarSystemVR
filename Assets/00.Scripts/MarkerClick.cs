using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerClick : MonoBehaviour
{
    public DialogManager dialogManager;
    public Transform markerCanvas;

    public void GazeClick()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < markerCanvas.transform.childCount; i++)
        {
            markerCanvas.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
        dialogManager.logs = DialogManager.Dialogs.DiaWrongMarker;
        dialogManager.StartCoroutine("DisplayDialog");
    }

    public void ResetMarker()
    {
        for (int i = 0;i < markerCanvas.transform.childCount;i++)
        {
            markerCanvas.GetChild(i).GetComponent<BoxCollider>().enabled = true;
            markerCanvas.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
