using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipGO : MonoBehaviour
{
    int currentPieces =0 ;
    int maxPieces =9;

     int currentHelp =0;
     int maxHelp  =3;

    public Image UIPieces;
    public Image UIHelp;
    public Transform[] spawnPoint = new Transform[3];
    public AudioClip[] Audio_spaceship_repair;
    private AudioSource spaceship_source;

    public AudioClip Audio_engine_start;
    public AudioClip Audio_engine_loop;



    private void Start()
    {
        UIPieces.fillAmount = 0.3f + 0.7f * ((float)currentPieces / maxPieces);
        UIHelp.fillAmount = 0.1f + 0.9f * ((float)currentHelp/maxHelp);
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
            UIPieces.fillAmount = 0.3f+0.7f*((float)currentPieces/maxPieces);

            if (currentPieces == maxPieces)
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
        UIHelp.fillAmount = 0.1f + 0.9f * ((float)currentHelp / maxHelp);
    }
}
