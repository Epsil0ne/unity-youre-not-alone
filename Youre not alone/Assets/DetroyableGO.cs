using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyableGO : MonoBehaviour
{
    public GameObject dropPrefab;

    public GameObject UIpress;

    public int numberHitBeforeBreak;
    private int currentHit = 0;
    public AudioClip[] Hit_sounds;
    public AudioClip[] Destroy_sounds;
    private AudioSource source;
    




    public void IsHit()
    {
        currentHit++;
        if (currentHit >= numberHitBeforeBreak)
        {

            var a = Instantiate(dropPrefab);
            a.transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
            if (currentHit == numberHitBeforeBreak)
            {
                source.clip = Destroy_sounds[UnityEngine.Random.Range(0, Destroy_sounds.Length)];
                source.Play();
            }
            Destroy(gameObject, 1);


        }
        else if(currentHit < numberHitBeforeBreak)
        {
            source.clip = Hit_sounds[UnityEngine.Random.Range(0, Hit_sounds.Length)];
            source.Play();
        }
       
    }




    void Start()
    {
        GameManager.destroyableList.Add(this);
        UIpress.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    void OnDestroy()
    {
        GameManager.destroyableList.Remove(this);
    }

    void OnTriggerEnter(Collider other)
    {
        UIpress.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        UIpress.SetActive(false);
    }

  
}
