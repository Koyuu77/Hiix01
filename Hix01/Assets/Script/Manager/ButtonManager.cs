using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private string clickedButton; //클릭한 버튼 종류를 string 값으로 받아오기
    [SerializeField] private Slider gauge;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TestButtonClic()
    {
        Debug.Log("Button Clicked");
    }

    public void ButtonClick(string clickedButton)
    //생성한 버튼에 스크립트를 넣어주고 변수를 입력해줘야함. 
    //그냥 버튼 오브젝트 이름을 넣어서 하는게 보기편하고 빠르다.
    {
        switch (clickedButton)
        {
            case "MenuButton":
                Debug.Log("MenuButton Clicked");
                GameManager.instance.panelOnOff = true;
                break;

            case "MakeChar":
                Debug.Log("MakeChar Clicked");
                GameManager.instance.makeChar = true;
                break;

            case "Tab1":
                Debug.Log("Tab1 Clicked");
                CharacterMakingManager.instace.tabNum = 1;
                break;

            case "Tab2":
                Debug.Log("Tab2 Clicked");
                CharacterMakingManager.instace.tabNum = 2;
                break;

            case "Tab3":
                Debug.Log("Tab3 Clicked");
                CharacterMakingManager.instace.tabNum = 3;
                break;

            case "Back":
                Debug.Log("Back Clicked");
                break;

            case "Ingredient1":
                Debug.Log("Ingredient1 Clicked");
                if (CharacterMakingManager.instace.tabNum == 1)
                {
                    CharacterMakingManager.instace.personatlity = 1;
                    Debug.Log("CharacterMakingManager.instace.personatlity = 1");
                    CharacterMakingManager.instace.tabNum = 2;
                }
                else if (CharacterMakingManager.instace.tabNum == 2)
                {
                    CharacterMakingManager.instace.outlook = 1;
                    Debug.Log("CharacterMakingManager.instace.outlook = 1");
                    CharacterMakingManager.instace.tabNum = 2;
                }
                else
                {
                    Debug.Log("Tab3 Ingredient Clicked");
                }
                break;

            case "Ingredient2":
                Debug.Log("Ingredient2 Clicked");
                if (CharacterMakingManager.instace.tabNum == 1)
                {
                    CharacterMakingManager.instace.personatlity = 2;
                    Debug.Log("CharacterMakingManager.instace.personatlity = 2");
                    CharacterMakingManager.instace.tabNum = 3;
                }
                else if (CharacterMakingManager.instace.tabNum == 2)
                {
                    CharacterMakingManager.instace.outlook = 2;
                    Debug.Log("CharacterMakingManager.instace.outlook = 2");
                    CharacterMakingManager.instace.tabNum = 3;
                }
                else
                {
                    Debug.Log("Tab3 Ingredient Clicked");
                }
                break;

            case "CharMakeTap":
                Debug.Log("CharMakeTap");
                GaugeScript.instance.ChangeValue();
                //게이지 다 채웠을 경우 처리
                break;

            case "NamingConfirmed":
                Debug.Log("NamingConfirmed");
                NamingScript.instance.NamingConfirmed();
                GameManager.instance.namingEnd = true;
                break;

            case "GoldButton":
                Debug.Log("GoldButton Clicked");
                MoneyManager.instance.AddMoney(GameManager.instance.data[4], 0);
                CharacterStatus.instance.OnTouch();
                CharacterStatus.instance.TalkChange();
                break;

            default:
                break;

        }
    }
}
