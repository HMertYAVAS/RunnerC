using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool success;
    public bool finish;

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
        finish = true;

        if (PlayerPrefs.GetInt("heart") < 3)
        {
            PlayerPrefs.SetInt("heart", 3);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);

    }

    public void NextLevel()
    {
        int tempLevel = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("level", tempLevel + 1);
        SceneManager.LoadScene(0);

    }

    public void PlayGame()
    {
        FinishController.instance.startPanel.SetActive(false);
        FinishController.instance.gamePanel.SetActive(true);
        finish = false;
    }

    public void UpgradeHeart()
    {
        if (PlayerPrefs.GetInt("totalGold") >= UpgradeUIs.instance.upgradeValueForHeart)
        {

            int tempHeart = PlayerPrefs.GetInt("heartX");
            PlayerPrefs.SetInt("heartX", tempHeart + 1);

            PlayerPrefs.SetInt("totalGold", PlayerPrefs.GetInt("totalGold") - UpgradeUIs.instance.upgradeValueForHeart);
            GoldUIs.instance.SetUIStartGold();
            UpgradeUIs.instance.LifeUpgrade();

        }
    }

    public void UpgradeGold()
    {
        if (PlayerPrefs.GetInt("totalGold") >= UpgradeUIs.instance.upgradeValueForGold)
        {

            int tempGold = PlayerPrefs.GetInt("goldX");
            PlayerPrefs.SetInt("goldX", tempGold + 1);

            PlayerPrefs.SetInt("totalGold", PlayerPrefs.GetInt("totalGold") - UpgradeUIs.instance.upgradeValueForGold);
            GoldUIs.instance.SetUIStartGold();
            UpgradeUIs.instance.GoldUpgrade();
        }

    }

}
