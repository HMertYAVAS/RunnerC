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
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);

    }
    
    public void PlayGame()
    {
        FinishController.instance.startPanel.SetActive(false);
        FinishController.instance.gamePanel.SetActive(true);
        finish = false;
    }

}
