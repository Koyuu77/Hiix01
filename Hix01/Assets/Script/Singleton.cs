using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Lang
{
    public List<string> value = new List<string>();
}

public class Singleton : MonoBehaviour
{
    const string langURL = "https://docs.google.com/spreadsheets/d/1BSwBpQ6QtrsRQA8mhMGaaPlgbcMbUa45pz8OE1IFW1Q/export?format=tsv";
    public List<Lang> Langs;

    public static Singleton instance;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

    }

    [ContextMenu("Get Lang")]
    void GetLang()
    {
        StartCoroutine(GetLangCo());
    }

    IEnumerator GetLangCo()
    {
        UnityWebRequest www = UnityWebRequest.Get(langURL);
        yield return www.SendWebRequest();
        SetLangList(www.downloadHandler.text);
    }

    void SetLangList(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        string[,] Sentence = new string[rowSize, columnSize];

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                Sentence[i, j] = column[j];
            }
        }

        Langs = new List<Lang>();
        //column : A,B,C...
        //row : 1,2,3...
        //lang(key,KR,EN)... * 14세트

        //row[0] = Key,KR,EN
        //row[1] = ui_1,메뉴,Menu
        //...
        for (int i = 0; i < rowSize; i++) //15번 돌아감
        {
            Lang lang = new Lang();
            lang.value.Add(Sentence[i, 0]);
            lang.value.Add(Sentence[i, 1]);
            lang.value.Add(Sentence[i, 2]);
            Langs.Add(lang);
        }

    }

}
