using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static PlayerGO player;
    public static ShipGO ship;
    public static List<RessourceGO> ressourcesList = new();
    public static List<DetroyableGO> destroyableList = new();

    private GameManager instance = null;
  
    void Start()
    {
        if (instance != null)        
            Destroy(gameObject);        
        else 
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))        
            AttemptGrab();        

        if (Input.GetKeyDown(KeyCode.E))        
            AttemptBreak();        
    }

   

    static void AttemptGrab()
    {       
        foreach (RessourceGO item in ressourcesList)
        {
            if (item.UIpressToGive.activeInHierarchy)
            {
                RessourceGO grabbableItem = item;
                if (grabbableItem.isFruitOnCactus)
                {
                    GameObject g = Instantiate(player.fruitPrefab, grabbableItem.transform.position, grabbableItem.transform.rotation);
                    Destroy(grabbableItem.gameObject);
                    grabbableItem = g.GetComponent<RessourceGO>();
                }

                player.GrabItem(grabbableItem);

                return;
            }
        }

    }
    private void AttemptBreak()
    {
        foreach (DetroyableGO item  in destroyableList)
        {
            if (item.UIpress.activeInHierarchy)
            {
                player.spawnParticle();
                item.IsHit();
                return;
            }
        }
    }



    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
}
