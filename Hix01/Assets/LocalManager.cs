using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LocalManager : MonoBehaviour
{
    public static LocalManager instance;
    [SerializeField] public string local;
    [SerializeField] private Text ui_1_Menu;
    [SerializeField] private Text ui_2_CharMaking;
    [SerializeField] private Text ui_3_Name;
    [SerializeField] private Text ui_4_Ok;
    [SerializeField] public int dataNum;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        local = "KR";
        dataNum = 1;

    }

    void Update()
    {
        if (local == "KR")
        {
            dataNum = 1;
            ui_1_Menu.text = Singleton.instance.Langs[1].value[dataNum].ToString();
            ui_2_CharMaking.text = Singleton.instance.Langs[2].value[dataNum].ToString();
            ui_3_Name.text = Singleton.instance.Langs[3].value[dataNum].ToString();
            ui_4_Ok.text = Singleton.instance.Langs[4].value[dataNum].ToString();
        }
        else if (local == "EN")
        {
            dataNum = 2;
            ui_1_Menu.text = Singleton.instance.Langs[1].value[dataNum].ToString();
            ui_2_CharMaking.text = Singleton.instance.Langs[2].value[dataNum].ToString();
            ui_3_Name.text = Singleton.instance.Langs[3].value[dataNum].ToString();
            ui_4_Ok.text = Singleton.instance.Langs[4].value[dataNum].ToString();
            //ui_1_Menu.text = Singleton.instance.Langs[1,2]
        }
    }
}
