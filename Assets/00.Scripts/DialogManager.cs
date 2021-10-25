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
    public CameraFadeRig camFade;
    public AudioBGMManager BGMManager;

    bool isDialogDone;
    string[] dialog;
    AudioClip[] clipDialog;
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
                    BGMManager.playBGM();
                    break;
                case Dialogs.DiaEarthMoonSize:
                    isDialogDone = false;
                    camFade.buttonClicked = true;
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
                    moonCanvas.GetComponent<RectTransform>().localPosition = new Vector3(0f, 15f, 0f);
                    moonCanvas.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 180f, 0f);
                    // moonCanvas.parent.GetComponent<RectTransform>().localPosition = new Vector3(0.507f, 0.66f, 2.751f);
                    // moonCanvas.parent.GetComponent<RectTransform>().localEulerAngles = new Vector3(23.75f, 295.002f, -0.048f);
                    moonCanvas.GetComponent<Image>().enabled = true;
                    SetDialogBelowPanel();
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
                    continentObjects[0].SetActive(false);
                    continentObjects[1].SetActive(false);
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
                    dialogPanel.transform.parent.GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = true;
                    camFade.buttonClicked = true;
                    break;
                case Dialogs.DiaMoonStart:
                    isDialogDone = false;
                    moonCanvas.GetChild(0).gameObject.SetActive(true);
                    moonCanvas.GetComponent<Image>().enabled = true;
                    moonCanvas.GetComponent<RectTransform>().localPosition = new Vector3(50f, 0f, 0f);
                    moonCanvas.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 160f, 0f);
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
                    moonCanvas.GetComponent<RectTransform>().localPosition = new Vector3(-71.5f, 0f, -22.5f);
                    moonCanvas.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 210f, 0f);
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
                    "안녕하세요, 저는 우주로의 여행을 돕기 위한 도롱이라고 합니다.",
                    "곧 우주선이 출발할 예정이에요. 준비되었나요?",
                    "5... 4... 3... 2... 1..."
                };
                clipDialog = new AudioClip[]
                {

                };
                break;
            case Dialogs.DiaWarp:
                dialog = new string[] {
                    "우주에 도착했습니다.",
                    "우주를 관찰할 수 있도록 '관찰모드' 를 활성화합니다."
                };
                break;
            case Dialogs.DiaSightseeing:
                dialog = new string[]
                {
                    "관찰모드가 활성화되어 우주를 관찰할 수 있습니다.",
                    "시선 가운데에 있는 하얀 점을 통해 각 행성에 있는 버튼을 선택할 수 있어요."
                };
                break;

            case Dialogs.DiaEarthMoonSize:
                dialog = new string[]
                {
                    "우리가 살고 있는 지구는 우리 이웃인 달에 비해 약 4배 정도 커요."
                };
                break;
            case Dialogs.DiaWrongMarker:
                dialog = new string[]
                {
                    "지구마커 틀림 (DiaWrongMarker)"
                    // 각 나라별로 대사 추가
                };
                break;
            case Dialogs.DiaEarthMarker:
                dialog = new string[]
                {
                    "지구에 조금 더 가까이 가볼게요.",
                    "지구에서 친구들이 살고 있는 우리나라가 어디에 있는지 맞춰볼까요?"
                };
                break;
            case Dialogs.DiaCorrectMarker:
                dialog = new string[]
                {
                    "정답이에요. 우주에서 봤을 때 여기가 우리나라의 위치랍니다."
                };
                break;
            case Dialogs.DiaEarthMap:
                dialog = new string[]
                {
                    "지금 지구 왼쪽에 보이는 건 지구의 지도입니다.",
                    "지금 보고 있는 동그란 지구를 한눈에 볼 수 있게 펴놓은 모양이에요."
                };
                break;
            case Dialogs.DiaEarthContinent:
                dialog = new string[]
                {
                    "지도에 지금 깜빡거리는 초록색 부분이 지구의 대륙입니다.",
                    "지구의 약 30% 가 대륙과 섬으로 이루어져 있어요."
                };
                break;
            case Dialogs.DiaEarthOcean:
                dialog = new string[]
                {
                    "지금 깜빡거리는 파란색 부분은 지구의 바다에요.",
                    "지구의 약 70% 이 바다로 이루어져 있어 지구의 큰 부분을 차지하고 있죠."
                };
                break;
            case Dialogs.DiaEarthFiveOcean:
                dialog = new string[]
                {
                    "지구의 바다는 5개로 나눌 수 있어요.",
                    "이걸 5대양이라고 해요.",
                    "우리나라에서 보이는 태평양부터 시작해서 인도양, 대서양, 북극해, 남극해로 이루어져 있죠."
                };
                break;
            case Dialogs.DiaEarthFiveOceanTwo:
                dialog = new string[]
                {
                    "5대양을 배웠으니 이제 7대륙을 알아볼게요."
                };
                break;
            case Dialogs.DiaEarthSevenContinents:
                dialog = new string[]
                {
                    "지구는 7개의 대륙으로 나눌 수 있답니다.",
                    "이 대륙들을 각각 아시아, 유럽, 아프리카, 오세아니아, 북아메리카, 남아메리카, 남극대륙으로 나누어 부르고 있어요."
                };
                break;
            case Dialogs.DiaEarthRot:
                dialog = new string[]
                {
                    "우리가 사는 이 지구는 '자전'을 하고 있어요.",
                    "지금 앞에 있는 지구를 자세히 살펴보면 천천히 회전하고 있는 게 보일 거예요.",
                    "이렇게 자기 자신을 축으로 회전하는걸 '자전'이라고 부릅니다.",
                    "지구가 회전하면서 태양의 빛을 받는 곳이 '낮'이 되고 반대로 태양의 빛을 못 받아 어두운 부분은 '밤' 이 된답니다.",
                    "지구에 대한 설명은 여기까지입니다.",
                    "아래쪽에 있는 행성 선택 버튼을 선택하면 행성 선택으로 돌아갑니다."
                };
                break;


            case Dialogs.DiaMoonStart:
                dialog = new string[]
                {
                    "빛의 각도에 따라서 달의 모양이 바뀔 수 있어요."
                };
                break;
            case Dialogs.DiaMoonRot:
                dialog = new string[]
                {
                    "이렇게 달의 모양이 바뀌어 보입니다.",
                    "달의 모양에 따라 이름도 여러 가지 있어요.",
                    "오늘은 기본적인 5개 모양의 달을 소개할게요."
                };
                break;
            case Dialogs.DiaMoonFirst:
                dialog = new string[]
                {
                    "초승달이에요. 오른쪽에만 살짝 보이는 모양의 달이죠."
                };
                break;
            case Dialogs.DiaMoonSecond:
                dialog = new string[]
                {
                    "상현달이에요. 오른쪽으로 차 있는 반달이에요."
                };
                break;
            case Dialogs.DiaMoonThird:
                dialog = new string[]
                {
                    "보름달이에요. 동그란 모양으로 꽉 차 있는 달이죠.",
                    "지구에서 볼 때 가장 달빛이 밝은 달이죠."
                };
                break;
            case Dialogs.DiaMoonFourth:
                dialog = new string[]
                {
                    "하현달이에요. 아까 상현달과는 반대로 왼쪽이 차 있는 반달이에요."
                };
                break;
            case Dialogs.DiaMoonFifth:
                dialog = new string[]
                {
                    "그믐달이에요. 초승달과 반대로 왼쪽으로 살짝 보이는 달입니다."
                };
                break;
            case Dialogs.DiaMoonDescription:
                dialog = new string[]
                {
                    "이제 지구에서는 볼 수 없는 달의 표면에 대해 알아볼게요.",
                    "달은 크게 고지, 바다, 분화구로 나뉘어요.",
                    "우선 고지부터 볼까요?"
                };
                break;
            case Dialogs.DiaMoonSea:
                dialog = new string[]
                {
                    "달의 어두운 부분은 달의 바다라고 불러요.",
                    "이탈리아의 한 철학자가 먼 옛날에 달도 지구처럼 바다가 있을 거라고 생각해서 생긴 이름이래요."
                };
                break;
            case Dialogs.DiaMoonMountain:
                dialog = new string[]
                {
                    "달의 표면의 하얀 부분이 고지에요.",
                    "고지의 광물들에 칼슘과 알루미늄이 많이 함유되어 있어 밝은 모습을 하고 있어요."
                };
                break;
            case Dialogs.DiaMoonCrater:
                dialog = new string[]
                {
                    "달을 자세히 보면 크고 작은 동그란 모양이 있는 곳은 분화구입니다.",
                    "가까이서 보면 움푹 파여있는 모양으로 되어있어요."
                };
                break;
            case Dialogs.DiaMoonLast:
                dialog = new string[]
                {
                    "달에 대한 설명은 여기까지입니다.",
                    "아래쪽에 있는 행성 선택 버튼을 선택하면 행성 선택으로 돌아갑니다."
                };
                break;

            case Dialogs.DiaSunStart:
                dialog = new string[]
                {
                    "우리 태양계의 중심인 태양은 크기가 굉장히 커요.",
                    "태양을 제외한 태양계의 모든 행성들을 합친 질량보다도 500배 더 크답니다.",
                    "지구에서 받는 빛 대부분은 태양에서 받고 있습니다.",
                    "낮에는 태양에서 직접적인 빛을 받고 밤에는 태양 빛을 달이 반사해서 지구를 비추지요.",
                    "태양은 굉장히 뜨거워서 태양의 내부는 섭씨 천오백만 도까지 올라간답니다."
                };
                break;
            case Dialogs.DiaOrbitStart:
                dialog = new string[]
                {
                    "태양을 중심으로 행성들이 회전하고 있어요.",
                    "우리가 사는 지구도 태양을 중심으로 회전하고 있는 중이에요.",
                    "각 행성이 태양을 한 바퀴 돌 때를 기준으로 그 행성의 1년이 지났다고 해요.",
                    "우리 지구는 1년의 기준인 365일 만에 태양을 한 바퀴 돌고 있습니다."
                };
                break;
            case Dialogs.DiaOrbitZoom:
                dialog = new string[]
                {
                    "회전하던 행성들을 일렬로 모아놓았어요.",
                    "총 8개의 행성이 태양을 중심으로 회전합니다.",
                    "태양부터 시작해서 순서대로 수성, 금성, 지구, 화성, 목성, 토성, 천왕성, 해왕성이 있어요.",
                    "중심이 되는 태양과 우리가 사는 지구도 포함해서 이 행성들을 '태양계'라고 부릅니다.",
                    "이제 행성 선택 화면으로 돌아갑니다."
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

                yield return new WaitForSeconds(2f - 2f);
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
            yield return new WaitForSeconds(0.01f);
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
        yield return new WaitForSeconds(5f - 0f);
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

    public void SetDialogBelowPanel()
    {
        dialogPanel.transform.parent.SetParent(moonCanvas);
        dialogPanel.transform.parent.SetAsLastSibling();
        dialogPanel.transform.parent.GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = false;
        dialogPanel.transform.parent.localPosition = new Vector3(0f, -55f, 15f);
        dialogPanel.transform.parent.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
}