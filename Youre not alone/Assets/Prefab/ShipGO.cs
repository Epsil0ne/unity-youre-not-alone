using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipGO : MonoBehaviour
{
  public  int currentPieces ;
  public  int maxPieces;

    public int currentHelp;
    public int maxHelp ;

    public Image UIPieces;
    public Image UIHelp;
    public Transform[] spawnPoint = new Transform[3];
    public AudioClip[] Audio_spaceship_repair;
    public AudioClip Audio_engine_start;
    public AudioClip Audio_engine_loop;
    private AudioSource spaceship_source;
   



    private void Start()
    {
        UIPieces.fillAmount = (float)currentPieces / maxPieces;
        UIHelp.fillAmount = (float)currentHelp/maxHelp;
        GameManager.ship = this;
        spaceship_source = GetComponent<AudioSource>();
        GetComponent<AudioSource>().loop = true;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger ship");
        if (GameManager.player.itemInHand != null && GameManager.player.itemInHand.resType == RessourceType.Ship)
        {
            GameManager.player.ItemIsGiven();
            currentPieces += 1;
            spaceship_source.clip = Audio_spaceship_repair[UnityEngine.Random.Range(0, Audio_spaceship_repair.Length)];
            spaceship_source.Play();
            UIPieces.fillAmount = (float)currentPieces / maxPieces;
            if (currentPieces == 9f)
            {
                spaceship_source.clip = Audio_engine_start;
                spaceship_source.Play();
                
                spaceship_source.clip = Audio_engine_loop;
                spaceship_source.PlayDelayed(Audio_engine_start.length);
            }
           
        }
    }
    private void OnDestroy()
    {
        GameManager.ship = null;
    }

    internal void HelpAdded()
    {
        currentHelp += 1;
        UIHelp.fillAmount = (float)currentHelp / maxHelp;
    }
}
