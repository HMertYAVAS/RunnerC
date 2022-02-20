using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LifeUIs : MonoBehaviour
{
    public static LifeUIs instance;

    public TMP_Text gameLife;

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
        SetUIGameLife();
    }

    public void SetUIGameLife()
    {
        gameLife.text = LifeController.instance.playerHeart.ToString();
    }

}
