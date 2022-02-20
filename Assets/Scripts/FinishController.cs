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
    public GameObject GamePanel;


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

        GoldUIs.instance.SetUISuccessGold();
        successPanel.SetActive(true);
        GamePanel.SetActive(false);

        //animation victory
        PlayerController.instance.anim.SetBool("victory", true);
    }

    public void FailFinish()
    {
        GameManager.instance.finish = true;
        PlayerController.instance.runBool = false;
        
        //animation idle
        PlayerController.instance.anim.SetBool("run", false);

        GoldUIs.instance.SetUIFailGold();
        failPanel.SetActive(true);
        GamePanel.SetActive(false);

    }
}
