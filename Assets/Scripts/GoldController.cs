using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldController : MonoBehaviour
{

    public static GoldController instance;

    [Header("Gold Values")]
    public int diamondVal;
    public int diamond5SideVal;

    [Header("Golds")]
    public int gold;
    public int totalGold;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void TotalGoldCalculate()
    {
        totalGold = gold + PlayerPrefs.GetInt("totalGold");
    }
}
