using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogManager : MonoBehaviour
{

    public enum Dialogs { 
        DiaStart, 
        DiaWarp,
        DiaSightseeing,

        DiaEarthMoonSize,
        DiaEarthRot,
        DiaEarthMarker,
        DiaWrongMarker,
        DiaCorrectMarker,

        DiaMoonStart,
        DiaMoonRot,
        DiaMoonFirst,
        DiaMoonSecond,
        DiaMoonThird,
        DiaMoonFourth,
        DiaMoonFifth,
        DiaMoonLast,

        DiaSunStart,
        DiaOrbitStart,
        DiaOrbitZoom,
        Dia
    }

    public Dialogs logs;

    public SpawnEffect spawnEffect;
    public Text shownText;
    public GameObject dialogPanel;
    public GameObject planetButtons;
    public PlayableDirector director;
    public GameObject markerCanvas;
    public MarkerClick markerClick;
    public GameObject earth;
    public GameObject moon;
    public GameObject backtoPlanets;
    public GameObject fadeScreen;
    public ArrangePlanets arrangePlanets;

    bool isDialogDone;
    string[] dialog;

    void Start()
    {
        director.played += Director_Played;
        logs = Dialogs.DiaStart;
        StartCoroutine(DisplayDialog());
    }

    void Update()
    {
        if(isDialogDone)
        {
            switch (logs)
            {
                case Dialogs.DiaStart:
                    isDialogDone = false;
                    logs = Dialogs.DiaWarp;
                    StartCoroutine(DisplayDialog());
                    break;
                case Dialogs.DiaWarp:
                    isDialogDone = false;
                    logs = Dialogs.DiaSightseeing;
                    StartCoroutine(sightseeingMode());
                    break;
                case Dialogs.DiaSightseeing:
                    isDialogDone = false;
                    planetButtons.SetActive(true);
                    break;
                case Dialogs.DiaEarthMoonSize:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaEarthRot:
                    isDialogDone = false;
                    backtoPlanets.SetActive(true);
                    break;
                case Dialogs.DiaEarthMarker:
                    markerCanvas.SetActive(true);
                    isDialogDone = false;
                    break;
                case Dialogs.DiaWrongMarker:
                    isDialogDone = false;
                    markerClick.ResetMarker();
                    break;
                case Dialogs.DiaCorrectMarker:
                    isDialogDone = false;
                    markerClick.ResetMarker();
                    markerCanvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    markerCanvas.SetActive(false);
                    director.Play();
                    break;
                case Dialogs.DiaMoonStart:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonRot:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonFirst:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonSecond:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonThird:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonFourth:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonFifth:
                    isDialogDone = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonLast:
                    isDialogDone = false;
                    backtoPlanets.SetActive(true);
                    break;
                case Dialogs.DiaSunStart:
                    isDialogDone = false;
                    fadeScreen.GetComponent<FadeScreen>().buttonClicked = true;
                    fadeScreen.tag = "SolarSystemFade";
                    break;
                case Dialogs.DiaOrbitStart:
                    isDialogDone = false;
                    arrangePlanets.StartArrage();
                    director.Play();
                    break;
                case Dialogs.DiaOrbitZoom:
                    isDialogDone = false;
                    print("here!");
                    fadeScreen.GetComponent<FadeScreen>().buttonClicked = true;
                    fadeScreen.tag = "SolarSystemDone";
                    break;
            }
        }
    }

    public IEnumerator DisplayDialog()
    {
        shownText.text = "";
        string currentText = "";
        yield return new WaitForSeconds(1f);
        dialogPanel.SetActive(true);
        switch (logs)
        {

            case Dialogs.DiaStart:
                dialog = new string[] {
                    "안녕, 나는 너의 우주여행을 도와줄 도롱이라고해!",
                    "곧 우주로 출발 할거야, 준비 됐어?",
                    "10... 9... 8... 7..."
                };
                break;
            case Dialogs.DiaWarp:
                dialog = new string[] {
                    "우주에 도착했어!",
                    "우주선의 내부때문에 우주가 잘 안보이네...",
                    "잠깐만 기다려줘, 우주선의 '관찰모드'를 금방 켜줄게"
                };
                break;
            case Dialogs.DiaSightseeing:
                dialog = new string[]
                {
                    "관찰모드 후 대사(DiaSightseeing)"
                };
                break;
            case Dialogs.DiaEarthMoonSize:
                dialog = new string[]
                {
                    "지구선택 후 대사(DiaEarthMoonSize)"
                };
                break;
            case Dialogs.DiaEarthRot:
                dialog = new string[]
                {
                    "지구자전 대사 (DiaEarthRot)"
                };
                break;
            case Dialogs.DiaWrongMarker:
                dialog = new string[]
                {
                    "지구마커 틀림 (DiaWrongMarker)"
                };
                break;
            case Dialogs.DiaEarthMarker:
                dialog = new string[]
                {
                    "지구마커 대사 (DiaEarthRot)"
                };
                break;
            case Dialogs.DiaCorrectMarker:
                dialog = new string[]
                {
                    "지구마커 정답 (DiaCorrectMarker)"
                };
                break;
            case Dialogs.DiaMoonStart:
                dialog = new string[]
                {
                    "달 시작 대사 (DiaMoonStart)"
                };
                break;
            case Dialogs.DiaMoonRot:
                dialog = new string[]
                {
                    "달 회전 후 대사 (DiaMoonStart)"
                };
                break;
            case Dialogs.DiaMoonFirst:
                dialog = new string[]
                {
                    "초승달 대사 (DiaMoonFirst)"
                };
                break;
            case Dialogs.DiaMoonSecond:
                dialog = new string[]
                {
                    "상현달 대사 (DiaMoonSecond)"
                };
                break;
            case Dialogs.DiaMoonThird:
                dialog = new string[]
                {
                    "보름달 대사 (DiaMoonThird)"
                };
                break;
            case Dialogs.DiaMoonFourth:
                dialog = new string[]
                {
                    "하현달 대사 (DiaMoonFourth)"
                };
                break;
            case Dialogs.DiaMoonFifth:
                dialog = new string[]
                {
                    "그믐달 대사 (DiaMoonFifth)"
                };
                break;
            case Dialogs.DiaMoonLast:
                dialog = new string[]
                {
                    "달 마지막 대사 (DiaMoonLast)"
                };
                break;
            case Dialogs.DiaSunStart:
                dialog = new string[]
                {
                    "태양 시작 대사 (DiaSunStart)"
                };
                break;
            case Dialogs.DiaOrbitStart:
                dialog = new string[]
                {
                    "태양계 관찰 대사 (DiaOrbitStart)"
                };
                break;
            case Dialogs.DiaOrbitZoom:
                dialog = new string[]
                {
                    "태양계 줌인 대사 (DiaOrbitZoom) + 태양계 행성들 설명 대사"
                };
                break;
        }                        

        int j = 0;
        for (int i = 0; i <= dialog[j].Length; i++)
        {
            currentText = dialog[j].Substring(0, i);
            shownText.text = currentText;
            if (i == dialog[j].Length)
            {

                yield return new WaitForSeconds(0.25f);
                if (dialog.Length > j+1)
                {
                    j += 1;
                    i = 0;
                }
                else
                {
                    yield return new WaitForSeconds(2f - 0f);
                    dialogPanel.SetActive(false);
                    isDialogDone = true;
                    StopAllCoroutines();
                }
            }
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator sightseeingMode()
    {
        spawnEffect.enabled = true;
        dialogPanel.SetActive(false);
        yield return new WaitForSeconds(4f);
        spawnEffect.enabled = false;
        StartCoroutine(DisplayDialog());
    }

    void Director_Played(PlayableDirector obj)
    {
        planetButtons.SetActive(false);
    }
    public void EarthMoonSignal()
    {
        director.Pause();
        logs = Dialogs.DiaEarthMoonSize;
        StartCoroutine(DisplayDialog());
    }
    public void EarthRotSignal()
    {
        director.Pause();
        logs = Dialogs.DiaEarthRot;
        earth.GetComponent<ObjectRotation>().enabled = true;
        moon.SetActive(false);
        StartCoroutine(DisplayDialog());
    }
    public void EarthMarkerSignal()
    {
        director.Pause();
        logs = Dialogs.DiaEarthMarker;
        StartCoroutine(DisplayDialog());
    }
    public void MoonStartSignal()
    {
        director.Pause();
        earth.GetComponent<SphereCollider>().enabled = true;
        logs = Dialogs.DiaMoonStart;
        StartCoroutine(DisplayDialog());
    }
    public void MoonRotSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonRot;
        StartCoroutine(DisplayDialog());
    }
    public void MoonFirstSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonFirst;
        StartCoroutine(DisplayDialog());
    }
    public void MoonSecondSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonSecond;
        StartCoroutine(DisplayDialog());
    }
    public void MoonThirdSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonThird;
        StartCoroutine(DisplayDialog());
    }
    public void MoonFourthSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonFourth;
        StartCoroutine(DisplayDialog());
    }
    public void MoonFifthSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonFifth;
        StartCoroutine(DisplayDialog());
    }
    public void MoonLastSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonLast;
        StartCoroutine(DisplayDialog());
    }
    public void SunStartSignal()
    {
        director.Pause();
        logs = Dialogs.DiaSunStart;
        StartCoroutine(DisplayDialog());
    }
    public void SolarSystemSig()
    {
        director.Pause();
        logs = Dialogs.DiaOrbitStart;
        StartCoroutine(DisplayDialog());
    }
    public void SunOrbitSignal()
    {
        director.Pause();
        logs = Dialogs.DiaOrbitZoom;
        StartCoroutine(DisplayDialog());
    }
}