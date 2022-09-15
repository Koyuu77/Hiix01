using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    [SerializeField] private float touchMoney;
    [SerializeField] private float adMoney;
    [SerializeField] private float moneyPerClick;
    [SerializeField] public Text touchMoneyText;
    [SerializeField] public Text adMoneyText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        touchMoney = PlayerPrefs.GetFloat("touchMoney");
        adMoney = PlayerPrefs.GetFloat("adMoney");
        moneyPerClick = PlayerPrefs.GetFloat("moneyPerClick", 1);

    }

    public void SetMoney(float tMoney, float aMoney)
    {
        touchMoney = tMoney;
        adMoney = aMoney;
        PlayerPrefs.SetFloat("touchMoney", touchMoney);
        PlayerPrefs.SetFloat("adMoney", adMoney);

    }

    public void AddMoney(float tMoney, float aMoney)
    {
        touchMoney += tMoney;
        adMoney += aMoney;
        SetMoney(touchMoney, adMoney);
    }

    public void SubMoney(float tMoney, float aMoney)
    {
        touchMoney -= tMoney;
        adMoney -= aMoney;
        SetMoney(touchMoney, adMoney);
    }

    public float GetTouchMoney()
    {
        return touchMoney;
    }

    public float GetAdMoney()
    {
        return adMoney;
    }

    public float GetMoneyPerClick()
    {
        return moneyPerClick;
    }

    public void SetMoneyPerClick(float newMoneyPerClick)
    {
        moneyPerClick = newMoneyPerClick;
        PlayerPrefs.SetFloat("moneyPerClick", moneyPerClick);
    }

    // Update is called once per frame
    void Update()
    {
        touchMoneyText.text = "터치 재화 : " + PlayerPrefs.GetFloat("touchMoney");
        adMoneyText.text = "광고 재화 : " + PlayerPrefs.GetFloat("adMoney");
    }
}
