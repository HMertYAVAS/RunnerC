using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllectTrig : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
         _particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Diamond5Side"))
        {
            GoldController.instance.gold += GoldController.instance.diamond5SideVal;
            _particleSystem.Play();
        }
        else
        {
            GoldController.instance.gold += GoldController.instance.diamondVal;
            _particleSystem.Play();
        }

        GoldUIs.instance.SetUIGameGold();
        
        //I close Just mesh.
        MeshFilter yourMesh;
        yourMesh = gameObject.GetComponent<MeshFilter>();
        yourMesh.sharedMesh = Resources.Load<Mesh>("none");

    }
}
