using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : MonoBehaviour
{
    const string SIZE_KEY = "Size";
    const string CROSSED_KEY = "Crossed";

    public static void SetSizeValue(int value)
    {
        PlayerPrefs.SetInt(SIZE_KEY, value);
    }
    public static void SetCrossedValue(int value)
    {
        PlayerPrefs.SetInt(CROSSED_KEY, value);
    }

    public static int GetSizeValue()
    {
        return PlayerPrefs.GetInt(SIZE_KEY);
    }

    public static int GetCrossedValue()
    {
        return PlayerPrefs.GetInt(CROSSED_KEY);
    }

}
