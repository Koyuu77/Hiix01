using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour
{
    public static GaugeScript instance;
    public Slider gauge;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        gauge = GetComponent<Slider>();
    }

    public void ChangeValue()
    {
        gauge.value += 0.1f;

        if (gauge.value >= 1)
        {
            Debug.Log("Tap End");
            GameManager.instance.charTapEnd = true;
        }
    }

}
