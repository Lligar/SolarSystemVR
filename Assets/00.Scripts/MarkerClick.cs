using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerClick : MonoBehaviour
{
    public DialogManager dialogManager;
    public Transform markerCanvas;

    public void GazeClick()
    {
        if (gameObject.name == "MarKor")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < markerCanvas.transform.childCount; i++)
            {
                markerCanvas.GetChild(i).GetComponent<BoxCollider>().enabled = false;
                markerCanvas.GetChild(i).GetComponent<Image>().enabled = false;
            }
            dialogManager.logs = DialogManager.Dialogs.DiaCorrectMarker;
            dialogManager.StartCoroutine("DisplayDialog");
        }
        else if (gameObject.name == "MoonMarker")
        {
            dialogManager.MoonMarkerClick();
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < markerCanvas.transform.childCount; i++)
            {
                markerCanvas.GetChild(i).GetComponent<BoxCollider>().enabled = false;
                markerCanvas.GetChild(i).GetComponent<Image>().enabled = false;
            }
            dialogManager.logs = DialogManager.Dialogs.DiaWrongMarker;
            dialogManager.StartCoroutine("DisplayDialog");
        }
    }

    public void ResetMarker()
    {
        for (int i = 0;i < markerCanvas.transform.childCount;i++)
        {
            markerCanvas.GetChild(i).GetComponent<BoxCollider>().enabled = true;
            markerCanvas.GetChild(i).GetComponent<Image>().enabled = true;
            markerCanvas.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
