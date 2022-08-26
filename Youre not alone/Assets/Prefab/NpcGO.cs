using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcGO : MonoBehaviour
{
    public int id;
    public GameObject UIpressToGive;
    public Image UIHearth;
    private int currentLike = 0;
    private int maxLike = 3;
    public Transform SpawnPoint;
    public GameObject ShipPiecePrefab;
    public string[] QuestTexts = new string[4];

    private void Start()
    {
        UIpressToGive.SetActive(false);
        UIHearth.fillAmount = (float)currentLike / maxLike;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (GameManager.player.itemInHand!=null && GameManager.player.itemInHand.resType == RessourceType.Wood)
        {
            UIpressToGive.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        UIpressToGive.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("e") && UIpressToGive.activeInHierarchy )
        {
            GameManager.player.ItemIsGiven();
            currentLike += 1;
            UIHearth.fillAmount = (float)currentLike/maxLike;
            UIpressToGive.SetActive(false);
            if (currentLike == maxLike)
            {
                transform.position = GameManager.ship.spawnPoint[id].position;
                transform.rotation = GameManager.ship.spawnPoint[id].rotation;
            }
         
            Instantiate(ShipPiecePrefab, SpawnPoint);
        }

      
    }
}
