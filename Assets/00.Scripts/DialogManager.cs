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
        DiaEarthMap,
        DiaEarthContinent,
        DiaEarthOcean,
        DiaEarthFiveOcean,
        DiaEarthFiveOceanTwo,
        DiaEarthSevenContinents,
        

        DiaMoonStart,
        DiaMoonRot,
        DiaMoonFirst,
        DiaMoonSecond,
        DiaMoonThird,
        DiaMoonFourth,
        DiaMoonFifth,
        DiaMoonDescription,
        DiaMoonSea,
        DiaMoonMountain,
        DiaMoonCrater,
        DiaMoonLast,

        DiaSunStart,
        DiaOrbitStart,
        DiaOrbitZoom,
        Dia
    }

    public Dialogs logs;

    public Text shownText;
    public GameObject dialogPanel;
    public GameObject planetButtons;
    public PlayableDirector director;
    public GameObject markerCanvas;
    public MarkerClick markerClick;
    public GameObject earth;
    public GameObject moon;
    public Transform moonCanvas;
    public GameObject sun;
    public GameObject backtoPlanets;
    public GameObject fadeScreen;
    public GameObject ship;
    public GameObject earthBackground;
    public ArrangePlanets arrangePlanets;
    public SpawnEffect[] respawns;
    public GameObject[] continentObjects;
    public GameObject[] continentTexts;

    bool isDialogDone;
    string[] dialog;
    float fadeFloat;
    int intI = 0;

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
                    ship.GetComponent<MoveShip>().enabled = true;
                    ship.GetComponent<ShakeShip>().enabled = true;
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
                    moonCanvas.GetComponent<RectTransform>().localPosition = new Vector3(920.1f, 286.8f, 383.4f);
                    moonCanvas.GetComponent<RectTransform>().localEulerAngles = new Vector3(-6.629f, -102.047f, -5.666f);
                    moonCanvas.GetComponent<Image>().enabled = true;
                    markerCanvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    markerCanvas.SetActive(false);
                    moon.SetActive(false);
                    continentObjects[0].SetActive(true);
                    continentObjects[1].SetActive(true);
                    continentObjects[2].SetActive(true);
                    logs = Dialogs.DiaEarthMap;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthMap:
                    isDialogDone = false;
                    continentObjects[1].GetComponent<Blink>().enabled = true;
                    logs = Dialogs.DiaEarthContinent;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthContinent:
                    isDialogDone = false;
                    continentObjects[1].GetComponent<Blink>().enabled = false;
                    continentObjects[2].GetComponent<Blink>().enabled = true;
                    logs = Dialogs.DiaEarthOcean;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthOcean:
                    isDialogDone = false;
                    continentObjects[2].GetComponent<Blink>().enabled = false;
                    continentObjects[2].SetActive(false);
                    for (int i = 0;i < 5; i ++)
                    {
                        continentTexts[i].SetActive(true);
                    }
                    continentTexts[0].transform.GetChild(0).GetComponent<Text>().text = "태평양";
                    continentTexts[1].transform.GetChild(0).GetComponent<Text>().text = "북극해";
                    continentTexts[2].transform.GetChild(0).GetComponent<Text>().text = "인도양";
                    continentTexts[3].transform.GetChild(0).GetComponent<Text>().text = "대서양";
                    continentTexts[4].transform.GetChild(0).GetComponent<Text>().text = "남극해";
                    logs = Dialogs.DiaEarthFiveOcean;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthFiveOcean:
                    isDialogDone = false;
                    for (int i = 0; i < 5; i++)
                    {
                        continentTexts[i].SetActive(false);
                    }
                    continentObjects[3].SetActive(true);
                    logs = Dialogs.DiaEarthFiveOceanTwo;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthFiveOceanTwo:
                    isDialogDone = false;
                    for (int i = 0; i < continentTexts.Length; i++)
                    {
                        continentTexts[i].SetActive(true);
                    }
                    continentObjects[3].SetActive(true);
                    continentTexts[0].transform.GetChild(0).GetComponent<Text>().text = "아시아";
                    continentTexts[1].transform.GetChild(0).GetComponent<Text>().text = "유럽";
                    continentTexts[2].transform.GetChild(0).GetComponent<Text>().text = "아프리카";
                    continentTexts[3].transform.GetChild(0).GetComponent<Text>().text = "북아메리카";
                    continentTexts[4].transform.GetChild(0).GetComponent<Text>().text = "남극대륙";
                    continentTexts[5].transform.GetChild(0).GetComponent<Text>().text = "오세아니아";
                    continentTexts[6].transform.GetChild(0).GetComponent<Text>().text = "남아메리카";
                    logs = Dialogs.DiaEarthSevenContinents;
                    StartCoroutine("DisplayDialog");
                    break;
                case Dialogs.DiaEarthSevenContinents:
                    isDialogDone = false;
                    for (int i = 0; i < continentTexts.Length; i++)
                    {
                        continentTexts[i].SetActive(false);
                    }
                    for (int i = 0; i < continentObjects.Length; i ++)
                    {
                        continentObjects[i].SetActive(false);
                    }
                    moonCanvas.GetComponent<Image>().enabled = false;
                    director.Play();
                    break;

                case Dialogs.DiaMoonStart:
                    isDialogDone = false;
                    moonCanvas.GetChild(0).gameObject.SetActive(true);
                    moonCanvas.GetComponent<Image>().enabled = true;
                    moonCanvas.GetComponent<RectTransform>().localPosition = new Vector3(-1.87895f, -0.03247f, 3.18009f);
                    moonCanvas.GetComponent<RectTransform>().localEulerAngles = new Vector3(-3.849f, 30.557f, 0f);
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
                case Dialogs.DiaMoonDescription:
                    isDialogDone = false;
                    logs = Dialogs.DiaMoonSea;
                    director.Play();
                    break;
                case Dialogs.DiaMoonMountain:
                    isDialogDone = false;
                    moonCanvas.GetChild(1).GetChild(0).gameObject.SetActive(false);
                    moonCanvas.GetComponent<Image>().enabled = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonSea:
                    isDialogDone = false;
                    moonCanvas.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    moonCanvas.GetComponent<Image>().enabled = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonCrater:
                    isDialogDone = false;
                    moonCanvas.GetChild(1).GetChild(2).gameObject.SetActive(false);
                    moonCanvas.GetComponent<Image>().enabled = false;
                    director.Play();
                    break;
                case Dialogs.DiaMoonLast:
                    isDialogDone = false;
                    moonCanvas.GetComponent<Image>().enabled = false;
                    earth.GetComponent<SphereCollider>().enabled = false;
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
        yield return new WaitForSeconds(1f - 1f);
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
            case Dialogs.DiaEarthMap:
                dialog = new string[]
                {
                    "지구지도 설명 시작 (DiaEarthMap)"
                };
                break;
            case Dialogs.DiaEarthContinent:
                dialog = new string[]
                {
                    "지구지도 대륙 설명 (DiaEarthContinent)"
                };
                break;
            case Dialogs.DiaEarthOcean:
                dialog = new string[]
                {
                    "지구지도 바다 설명 (DiaEarthOcean)"
                };
                break;
            case Dialogs.DiaEarthFiveOcean:
                dialog = new string[]
                {
                    "지구지도 5대양 설명 (DiaEarthFiveOcean)"
                };
                break;
            case Dialogs.DiaEarthFiveOceanTwo:
                dialog = new string[]
                {
                    "지구지도 5대양 설명 후 (DiaEarthFiveOceanTwo)"
                };
                break;
            case Dialogs.DiaEarthSevenContinents:
                dialog = new string[]
                {
                    "지구지도 7대륙 설명 (DiaEarthMap)"
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
            case Dialogs.DiaMoonDescription:
                dialog = new string[]
                {
                    "달 설명 시작 (DiaMoonDescription)"
                };
                break;
            case Dialogs.DiaMoonSea:
                dialog = new string[]
                {
                    "달 바다 설명 (DiaMoonSea)"
                };
                break;
            case Dialogs.DiaMoonMountain:
                dialog = new string[]
                {
                    "달 고지 설명 (DiaMoonMountain)"
                };
                break;
            case Dialogs.DiaMoonCrater:
                dialog = new string[]
                {
                    "달 분화구 설명 (DiaMoonCrater)"
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

                yield return new WaitForSeconds(0.1f - 0.9999f);
                if (dialog.Length > j+1)
                {
                    j += 1;
                    i = 0;
                }
                else
                {
                    yield return new WaitForSeconds(2f - 2f);
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
        Color glassRenderer;
        GameObject glassObject;

        glassObject = ship.transform.Find("Glass").gameObject;
        glassRenderer = ship.transform.Find("Glass").GetComponent<MeshRenderer>().material.color;

        for (int i = 0; i < respawns.Length; i++)
        {
            respawns[i].enabled = true;
        }
        dialogPanel.SetActive(false);

        while(glassRenderer.a > 0f)
        {
            fadeFloat -= 0.005f;
            glassRenderer = new Vector4(glassRenderer.r, glassRenderer.g, glassRenderer.b, fadeFloat);
            if(glassRenderer.a <= 0f)
            {
                glassObject.SetActive(false);
            }
            yield return null;
        }
        yield return new WaitForSeconds(4f - 2f);
        for (int i = 0; i < respawns.Length; i++)
        {
            respawns[i].enabled = false;
        }
        StartCoroutine(DisplayDialog());
    }

    IEnumerator ArriveSpace()
    {
        ship.GetComponent<MoveShip>().enabled = false;
        ship.GetComponent<ShakeShip>().enabled = false;
        sun.SetActive(true);
        earth.SetActive(true);
        earthBackground.SetActive(false);

        yield return new WaitForSeconds(5f - 5f);
        StartCoroutine("DisplayDialog");
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
    public void MoonDescriptionSignal()
    {
        director.Pause();
        logs = Dialogs.DiaMoonDescription;
        moonCanvas.GetChild(0).gameObject.SetActive(false);
        moonCanvas.GetComponent<Image>().enabled = false;
        StartCoroutine(DisplayDialog());
    }
    public void MoonMarkerClick()
    {
        moonCanvas.GetComponent<Image>().enabled = true;
        moonCanvas.GetChild(1).GetChild(intI).gameObject.SetActive(true);
        moonCanvas.GetChild(2).gameObject.SetActive(false);
        StartCoroutine(DisplayDialog());
        intI += 1;
        if (intI == 3)
        {
            intI = 0;
        }
    }
    public void MoonMountainSignal()
    {
        director.Pause();
        moonCanvas.GetChild(2).gameObject.SetActive(true);
        logs = Dialogs.DiaMoonMountain;
    }

    public void MoonSeaSignal()
    {
        director.Pause();
        moonCanvas.GetChild(2).gameObject.SetActive(true);
        logs = Dialogs.DiaMoonSea;
    }

    public void MoonCraterSignal()
    {
        director.Pause();
        moonCanvas.GetChild(2).gameObject.SetActive(true);
        logs = Dialogs.DiaMoonCrater;
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