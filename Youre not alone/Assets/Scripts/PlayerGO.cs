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

    private void GrabItem(RessourceGO item)
    {
        DropItem(itemInHand);
        itemInHand = item;
        item.GetComponent<Collider>().enabled = false;
        item.UIpressToGive.SetActive( false);
    }
    private void DropItem(RessourceGO item)
    {
        if (item == null)        
            return;
        
        itemInHand = null;
        item.GetComponent<Collider>().enabled = true;
        item.UIpressToGive.SetActive( true);
        item.transform.position = new Vector3(item.transform.position.x, 0.3f, item.transform.position.z);
    }

    private void OnDestroy()
    {
        GameManager.player = null;
    }
 
}
