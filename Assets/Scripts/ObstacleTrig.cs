using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrig : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Finish"))
        {
            FinishController.instance.SuccessFinish();
        }
        else
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            LifeController.instance.LifeControl();
        }
    }
}
