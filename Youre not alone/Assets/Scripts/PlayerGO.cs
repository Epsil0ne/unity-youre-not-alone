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
    public AudioClip audio_grab_item;
    public AudioClip audio_drop_item;
    private AudioSource source;

    public void spawnParticle()
    {
        particleHit.GetComponent<ParticleSystem>().Play();
        smallImpulse.GenerateImpulse();
    }

    void Start()
    {
        GameManager.player = this;
        source = GetComponent<AudioSource>();
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
        source.clip = audio_grab_item;
        source.Play();
    }

   public  void DropItem()
    {
        if (itemInHand == null)
            return;

        itemInHand.Drop();
        source.clip = audio_drop_item;
        source.Play();

        itemInHand = null;

             
    }

     void OnDestroy()
    {
        GameManager.player = null;
    }
 
}
