using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGO : MonoBehaviour
{

   public RessourceGO itemInHand = null;
    public GameObject fruitPrefab;
   public GameObject particleHit;
    public CinemachineImpulseSource smallImpulse;


    public void spawnParticle()
    {
        particleHit.GetComponent<ParticleSystem>().Play();
        smallImpulse.GenerateImpulse();
    }

    void Start()
    {
        GameManager.player = this;
    }

    void Update()
    {
        if (itemInHand!=null)
        {
            itemInHand.gameObject.transform.position = transform.position + transform.forward+transform.up;
        }
    }

    public void ItemIsGiven()
    {
        Destroy(itemInHand.gameObject);
    }

    public void GrabItem(RessourceGO item)
    {
        DropItem();
        itemInHand = item;
        item.Grab();
    }

   public  void DropItem()
    {
        if (itemInHand == null)
            return;

        itemInHand.Drop();

        itemInHand = null;

             
    }

     void OnDestroy()
    {
        GameManager.player = null;
    }
 
}
