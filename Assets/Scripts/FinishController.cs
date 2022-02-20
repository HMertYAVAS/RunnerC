using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{

    public static FinishController instance;


    [Header("Panels")]
    public GameObject successPanel;
    public GameObject failPanel;
    public GameObject startPanel;


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

    public void SuccessFinish()
    {
        GameManager.instance.finish = true;
        GameManager.instance.success = true;

        GoldController.instance.TotalGoldCalculate();
        PlayerPrefs.GetInt("totalGold", GoldController.instance.totalGold);


        successPanel.SetActive(true);
    }

    public void FailFinish()
    {
        GameManager.instance.finish = true;
        PlayerController.instance.runBool = false;

        failPanel.SetActive(true);

    }
}
