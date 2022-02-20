using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUIs : MonoBehaviour
{
    public static GoldUIs instance;

    [Header("Gold Text")]
    public TMP_Text failGold;
    public TMP_Text failTotalGold;
    public TMP_Text successGold;
    public TMP_Text successTotalGold;
    public TMP_Text gameGold;

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

    public void SetUIFailGold()
    {
        failGold.text = GoldController.instance.gold.ToString();
        failTotalGold.text = GoldController.instance.totalGold.ToString();
    }

    public void SetUISuccessGold()
    {
        successGold.text = GoldController.instance.gold.ToString();
        successTotalGold.text = GoldController.instance.totalGold.ToString();
    }

    public void SetUIGameGold()
    {
        gameGold.text = GoldController.instance.gold.ToString();
    }
}
