using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1U9elaRzGuQRVDoKt87hcae4G6R4RUCpr0FbPuLT86GM/export?format=tsv&range=A2:J";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
    }
}
