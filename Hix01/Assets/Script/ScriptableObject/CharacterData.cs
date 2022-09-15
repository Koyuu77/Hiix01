using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = int.MaxValue)]

public class CharacterData : ScriptableObject
{
    /*
    [SerializeField] private string stage;
    public string Stage { get { return stage; } }
    [SerializeField] private float heartPercent;
    public float HeartPercent { get { return heartPercent; } }
    [SerializeField] private float moisPercent;
    public float MoisPercent { get { return moisPercent; } }
    [SerializeField] private float tempFigure;
    public float TempFigure { get { return tempFigure; } }

    [SerializeField] private float goldPerTouch;
    public float GoldPerTouch { get { return goldPerTouch; } }
    [SerializeField] private float heartPerTouch;
    public float HeartPerTouch { get { return heartPerTouch; } }
    [SerializeField] private float tempPerTouch;
    public float TempPerTouch { get { return tempPerTouch; } }
    [SerializeField] private float decLove;
    public float DecLove { get { return decLove; } }
    [SerializeField] private float decMoi;
    public float DecMoi { get { return decMoi; } }
    [SerializeField] private float decTemp;
    public float DecTemp { get { return decTemp; } }*/

    [SerializeField] private static string stage;
    [SerializeField] public static string Stage { get { return stage; } }

    [SerializeField] private float[] data = new float[10];
    [SerializeField] public static float[] Data = new float[10];
}
