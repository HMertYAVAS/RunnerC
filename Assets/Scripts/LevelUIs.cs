using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUIs : MonoBehaviour
{
    public static LevelUIs instance;

    public int levelcount;

    [Header("Panel")]
    public TMP_Text levelUIStart;
    public TMP_Text levelUIGame;

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
        LevelShowing();
    }

    public void LevelShowing()
    {
        int tempLevel = PlayerPrefs.GetInt("level");

        levelUIStart.text = tempLevel.ToString();
        levelUIGame.text = tempLevel.ToString();
    }
}
