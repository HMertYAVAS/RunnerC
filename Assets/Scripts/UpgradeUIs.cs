using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUIs : MonoBehaviour
{
    public static UpgradeUIs instance;

    public int upgradeValueForGold;
    public int upgradeValueForHeart;

    [Header("Panels")]
    public TMP_Text goldXVal;
    public TMP_Text goldX;
    public TMP_Text heartXVal;
    public TMP_Text heartX;

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

    private void Start()
    {
        GoldUpgrade();
        LifeUpgrade();
    }

    public void GoldUpgrade()
    {
        upgradeValueForGold = (30 + (50 * PlayerPrefs.GetInt("goldX")));
        goldXVal.text = upgradeValueForGold.ToString();
        goldX.text = (1 + PlayerPrefs.GetInt("goldX")).ToString() + "X";
    }

    public void LifeUpgrade()
    {
        upgradeValueForHeart = (30 + (50 * PlayerPrefs.GetInt("heartX")));
        heartXVal.text = upgradeValueForHeart.ToString();
        heartX.text = (1 + PlayerPrefs.GetInt("heartX")).ToString() + "X";
    }
}
