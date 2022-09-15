using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public static CharacterStatus instance;
    [Header("Character Status")]
    [SerializeField] public string charName; //캐릭터의 이름
    [SerializeField] public int personatlity; //캐릭터의 성격
    [SerializeField] public int outlook; //캐릭터의 외모
    [SerializeField] private float love; //애정 수치
    [SerializeField] private float humid; //수분 수치
    [SerializeField] private float temp; //온도 수치

    [Header("Character Outlook")]
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] sprite;

    [Header("Text")]
    [SerializeField] public Text loveText;
    [SerializeField] public Text humidText;
    [SerializeField] public Text tempText;
    [SerializeField] public Text talkText;

    [Header("Variables")]
    [SerializeField] private int delayTime;
    [SerializeField] private int talkChangeVar;
    [SerializeField] private float lovDec;
    [SerializeField] private float humDec;
    [SerializeField] private float temDec;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        VariableInit();
        CharSetting();
        StartCoroutine(VariablePerTime(delayTime));
    }

    void VariableInit()
    {
        love = GameManager.instance.data[1];
        humid = GameManager.instance.data[2];
        temp = GameManager.instance.data[3];
        lovDec = GameManager.instance.data[7];
        humDec = GameManager.instance.data[8];
        temDec = GameManager.instance.data[9];
        delayTime = 3;

    }

    void CharSetting()
    {
        charName = PlayerPrefs.GetString("charName");
        sprite = Resources.LoadAll<Sprite>("Sprite");
        outlook = CharacterMakingManager.instace.outlook;
        personatlity = CharacterMakingManager.instace.personatlity;
        image.sprite = sprite[outlook - 1];

    }

    void VariableUpdate()
    {
        string lov = love.ToString("F1");
        string hum = humid.ToString("F1");
        string tem = temp.ToString("F1");
        loveText.text = "애정 : " + lov;
        humidText.text = "수분 : " + hum;
        tempText.text = "온도 : " + tem + "%c";
    }

    public void OnTouch()
    {
        love += GameManager.instance.data[5];
        temp += GameManager.instance.data[6];
    }

    public void TalkChange()
    {
        talkChangeVar += 1;
        if (talkChangeVar >= 10)
        {
            if (personatlity == 1)
            {
                int a = Random.Range(1, 5);
                talkText.text = Singleton.instance.Langs[a + 4].value[LocalManager.instance.dataNum].ToString();
            }

            else if (personatlity == 2)
            {
                int a = Random.Range(1, 5);
                talkText.text = Singleton.instance.Langs[a + 9].value[LocalManager.instance.dataNum].ToString();
            }

            talkChangeVar = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VariableUpdate();
    }

    IEnumerator VariablePerTime(float delay)
    {
        Debug.Log("VariablePerTime Call");
        love -= lovDec;
        humid -= humDec;
        temp -= temDec;
        yield return new WaitForSeconds(delay);
        StartCoroutine(VariablePerTime(delayTime));
    }

    void NullCheck()
    {
        if (loveText == null)
        {
            Debug.LogWarning("loveText is null");
        }
        if (humidText == null)
        {
            Debug.LogWarning("humidText is null");
        }
        if (tempText == null)
        {
            Debug.LogWarning("tempText is null");
        }
        if (image == null)
        {
            Debug.LogWarning("sprite is null");
        }
        if (talkText == null)
        {
            Debug.LogWarning("talkText is Null");
        }
        else
        {
            Debug.Log("CharacterStatus Null Check end. All good");
        }
    }

}
