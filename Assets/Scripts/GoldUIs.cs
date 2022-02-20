using System.Collections;
using System.Collections.Generic;
using UnityEngine;
TMPro;

public class GoldUIs : MonoBehaviour
{
    public static GameManager instance;

    [Header("Gold Text")]
    public TMP_Text failGold;
    public TMP_Text failTotalGold;
    public TMP_Text successGold;
    public TMP_Text successTotalGold;

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
}
