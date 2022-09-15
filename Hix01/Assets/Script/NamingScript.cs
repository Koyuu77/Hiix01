using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamingScript : MonoBehaviour
{
    public static NamingScript instance;
    public string charName;
    [SerializeField] private InputField nameInputField;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void NamingConfirmed()
    {
        PlayerPrefs.SetString("charName", nameInputField.text);
    }

}
