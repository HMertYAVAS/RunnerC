using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FinishController : MonoBehaviour
{

    public static FinishController instance;

    public CinemachineVirtualCamera finalCamera;
    public CinemachineVirtualCamera gameCamera;

    [Header("Panels")]
    public GameObject successPanel;
    public GameObject failPanel;
    public GameObject startPanel;
    public GameObject gamePanel;


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
        finalCamera.Priority = 9;
    }

    public void SuccessFinish()
    {
        GameManager.instance.finish = true;
        GameManager.instance.success = true;

        GoldController.instance.TotalGoldCalculate();
        GoldController.instance.TotalGoldSet();

        GoldUIs.instance.SetUISuccessGold();
        successPanel.SetActive(true);
        gamePanel.SetActive(false);

        //camera change
        finalCamera.Priority = 11;

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
        gamePanel.SetActive(false);
        

    }
}
