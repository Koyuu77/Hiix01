using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientText : MonoBehaviour
{
    public static IngredientText instance;
    [SerializeField] private Text ingText;
    //[SerializeField] private 
    // Start is called before the first frame update
    void Awake()
    {
        NullCheck();
        instance = this;
        ingText.text = "재료 선택1";
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterMakingManager.instace.tabNum == 1)
        {
            ingText.text = "재료 선택1";
        }
        else if (CharacterMakingManager.instace.tabNum == 2)
        {
            ingText.text = "재료 선택2";
        }
        else
        {
            ingText.text = "재료 선택3";
        }
    }


    void NullCheck()
    {
        if (ingText == null)
        {
            Debug.LogWarning("text is null");
        }
        else
        {
            Debug.Log("IngredientText Null check end. All good");
        }

    }
}
