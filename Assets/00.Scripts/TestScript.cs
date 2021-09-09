using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public DialogManager diaMan;
    DialogManager.Dialogs logs;


    
    public void TestButton()
    {
        print("aadfasdfsdfafadf");
        diaMan.logs = DialogManager.Dialogs.DiaMoonStart;
        diaMan.StartCoroutine("DisplayDialog");
    }

}
