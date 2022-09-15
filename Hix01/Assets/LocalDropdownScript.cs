using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalDropdownScript : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
    // Update is called once per frame
    void Awake()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
    }

    void Update()
    {
        if (dropdown.value == 0) //KR
        {
            LocalManager.instance.local = "KR";
        }
        else if (dropdown.value == 1) //EN
        {
            LocalManager.instance.local = "EN";
        }
    }
}
