using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMakingManager : MonoBehaviour
{
    public static CharacterMakingManager instace;

    [SerializeField] public int personatlity; //성격 재료에따른 수치
    [SerializeField] public int outlook; //외모 재료에 다른 수치
    [SerializeField] public int tabNum; //현재 탭 수치 ex)1일때 성격, 2일때 외모
    // Start is called before the first frame update
    void Awake()
    {
        instace = this;
        personatlity = 0;
        outlook = 0;
        tabNum = 1;
    }
    /*
    public void PersonalitySetting() //성격 세팅
    {
        switch (personatlity)
        {
            case 1:
                CharacterStatus.instance.personatlity = 1;
                break;

            case 2:
                CharacterStatus.instance.personatlity = 2;
                break;

            default:
                break;
        }
    }

    public void OutlookSetting() //외모 세팅
    {
        switch (outlook)
        {
            case 1:
                CharacterStatus.instance.outlook = 1;
                break;

            case 2:
                CharacterStatus.instance.outlook = 2;
                break;

            default:
                break;
        }
    }
*/
    void SettingEnd()
    {
        GameManager.instance.isCharExst = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (personatlity != 0 && outlook != 0)
        {
            SettingEnd();
        }
    }
}
