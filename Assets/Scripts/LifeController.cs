using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;

    public int playerHeart;

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


    public void LifeControl()
    {
        if (playerHeart == 1)
        {
            playerHeart--;
            FinishController.instance.FailFinish();
        }
        else
        {
            playerHeart--;
        }
    }

}
