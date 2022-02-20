using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllectTrig : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Diamond5Side"))
        {
            GoldController.instance.gold += GoldController.instance.diamond5SideVal;
        }
        else
        {
            GoldController.instance.gold += GoldController.instance.diamondVal;
        }

        this.gameObject.SetActive(false);
    }
}
