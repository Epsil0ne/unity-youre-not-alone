using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGO : MonoBehaviour
{

   public RessourceGO itemInHand = null;
    public GameObject fruitPrefab;

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
            print("g key was pressed");
            foreach (RessourceGO item in GameManager.ressourcesList)
            {
                float dist = Vector3.Distance(transform.position, item.transform.position);
                if (dist< minDist)
                {
                    minDist = dist;
                    closeItem = item;
                }
            }
            Debug.Log(minDist);
            if (minDist<4)
            {
                GameManager.player.GrabItem(closeItem);
            }
        }

        if (itemInHand!=null)
        {
            itemInHand.gameObject.transform.position = transform.position + transform.forward+transform.up;
        }
    }

    public void ItemIsGiven()
    {
        Destroy(itemInHand.gameObject);
    }

     void GrabItem(RessourceGO item)
    {
        DropItem(itemInHand);

        if (item.isFruitOnCactus)
        {
           GameObject g =  Instantiate(fruitPrefab, item.transform.position, item.transform.rotation);
            Destroy(item.gameObject);
            item = g.GetComponent<RessourceGO>();
        }

        itemInHand = item;

        item.Grab();      
    }

     void DropItem(RessourceGO item)
    {
        if (item == null)
            return;

        itemInHand = null;

        item.Drop();       
    }

     void OnDestroy()
    {
        GameManager.player = null;
    }
 
}
