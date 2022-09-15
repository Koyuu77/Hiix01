using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//​​​​​​​​​

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Variables for Check")]
    [SerializeField] public bool isCharExst; //캐릭터 유무 체크
    [SerializeField] public bool makeChar; //캐릭터 생성 체크 
    [SerializeField] public bool panelOnOff; //메뉴 패널 On Off 체크
    [SerializeField] public bool charTapEnd; //캐릭터 생성 탭 완료 체크
    [SerializeField] public bool namingEnd; //이름 짓기 완료 체크

    [Header("UI")]
    [SerializeField] private GameObject menuPanel; //메뉴 패널 
    [SerializeField] private GameObject charUI; //캐릭터UI(캐릭터 스프라이트/대사)
    [SerializeField] private GameObject uiAfterMakeChar; //캐릭터 생성 후의 UI 
    [SerializeField] private GameObject uiBeforeMakeChar; //캐릭터 생성 전의 UI (캐릭터 생성창이 떠야함)
    [SerializeField] private GameObject uiMakeCharTap; //캐릭터 생성 후 탭하는 UI
    [SerializeField] private GameObject uiMakeCharNaming; //이름 생성 UI

    [Header("Data")]
    [SerializeField] private CharacterData characterData; //캐릭터 수치 데이터파일 (구글 드라이브 연동)
    [SerializeField] private int stage; //현재 스테이지(CharacterStage)
    [SerializeField] public float[] data = new float[10];
    private const string URL = "https://docs.google.com/spreadsheets/d/1U9elaRzGuQRVDoKt87hcae4G6R4RUCpr0FbPuLT86GM/export?format=tsv&range=A2:J";


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        panelOnOff = false;
        charTapEnd = false;
        stage = 1;
        NullCheck();
        StartCoroutine("DownloadCharacterStatus");
    }

    // Update is called once per frame
    void Update()
    {
        UICheck();
    }

    void FixedUpdate()
    {
        if (Input.touchCount >= 1)
        {
            if (Input.GetTouch(0).deltaTime > 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                for (int i = 0; i <= 3; i++)
                {
                    MoneyManager.instance.AddMoney(GameManager.instance.data[4], 0);
                    CharacterStatus.instance.OnTouch();
                    CharacterStatus.instance.TalkChange();
                }
                Debug.Log("PetPet");
            }
        }

    }

    private void UICheck()//UI 변환을 담당
    {
        if (isCharExst == false)
        {
            if (panelOnOff == true)
            {
                menuPanel.SetActive(true);
                uiBeforeMakeChar.SetActive(true);
                uiAfterMakeChar.SetActive(false);
                uiMakeCharTap.SetActive(false);

                if (makeChar == true)
                {
                    uiBeforeMakeChar.SetActive(false);
                    uiMakeCharTap.SetActive(false);
                    uiAfterMakeChar.SetActive(true);
                }

            }
            else if (panelOnOff == false)
            {
                menuPanel.SetActive(false);
            }
        }

        else if (isCharExst == true)
        {
            if (panelOnOff == true)
            {
                menuPanel.SetActive(true);
            }
            else if (panelOnOff == false)
            {
                menuPanel.SetActive(false);
            }

            if (CharacterMakingManager.instace.personatlity != 0 && CharacterMakingManager.instace.outlook != 0)
            {
                uiBeforeMakeChar.SetActive(false);
                uiAfterMakeChar.SetActive(false);
                uiMakeCharTap.SetActive(true);
            }

            if (charTapEnd == true)
            {
                uiMakeCharNaming.SetActive(true);
            }

            if (namingEnd == true)
            {
                charUI.SetActive(true);
                uiMakeCharNaming.SetActive(false);
                menuPanel.SetActive(false);
            }

        }


    }

    private void NullCheck()
    {
        if (menuPanel == null)
        {
            Debug.LogWarning("menuPanel is null");
        }

        else if (uiBeforeMakeChar == null)
        {
            Debug.LogWarning("uiBeforeMakeChar is null");
        }

        else if (uiAfterMakeChar == null)
        {
            Debug.LogWarning("uiAfterMakeChar is null");
        }

        else
        {
            Debug.Log("GameManager Null check end. All good.");
        }
    }

    IEnumerator DownloadCharacterStatus()
    {

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        SetCharacterStatus(www.downloadHandler.text);
        DataInput(www.downloadHandler.text);

    }

    void SetCharacterStatus(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            //Debug.Log(i + "번");
            for (int j = 0; j < columnSize; j++)
            {
                //print(column[j]);
            }
        }
    }

    void DataInput(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        Debug.Log("columnSize is" + columnSize);
        if (stage == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                string[] column = row[i].Split('\t');
                for (int j = 0; j < columnSize; j++)
                {
                    if (j != 0)
                    {
                        data[j] = float.Parse(column[j]);
                    }
                    print(column[j]);
                }
            }
        }
        else if (stage == 2)
        {
            for (int i = 1; i < 2; i++)
            {
                string[] column = row[i].Split('\t');
                for (int j = 0; j < columnSize; j++)
                {
                    if (j != 0)
                    {
                        data[j] = float.Parse(column[j]);
                    }
                    print(column[j]);
                }
            }
        }

    }

}
