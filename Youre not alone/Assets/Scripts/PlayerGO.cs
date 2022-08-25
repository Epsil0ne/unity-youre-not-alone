using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGO : MonoBehaviour
{

   public RessourceGO itemInHand = null;


    void Start()
    {
        GameManager.player = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            float minDist = 100f;
            RessourceGO closeItem = null;
            print("space key was pressed");
            foreach (RessourceGO item in GameManager.ressourcesList)
            {
                float dist = Vector3.Distance(transform.position, item.transform.position);
                if (dist< minDist)
                {
                    minDist = dist;
                    closeItem = item;
                }
            }
            if (minDist<3)
            {
                GameManager.player.GrabItem(closeItem);
            }
        }

        if (itemInHand!=null)
        {
            itemInHand.gameObject.transform.position = transform.position + transform.forward+transform.up;
        }
    }

    internal void ItemIsGiven()
    {
        Destroy(itemInHand.gameObject);
    }

    private void GrabItem(RessourceGO closeItem)
    {
        itemInHand = closeItem;
        closeItem.GetComponent<Collider>().enabled = false;
        closeItem.GetComponentInChildren<Canvas>().enabled = false;
    }
    private void DropItem(RessourceGO closeItem)
    {
        itemInHand = null;
        closeItem.GetComponent<Collider>().enabled = true;
        closeItem.GetComponentInChildren<Canvas>().enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.player = null;
    }
 
}
