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




    public void IsHit()
    {
        currentHit++;
        if (currentHit>=numberHitBeforeBreak)
        {
            var a = Instantiate(dropPrefab);
            a.transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
            Destroy(gameObject);
        }
    }




    void Start()
    {
        GameManager.destroyableList.Add(this);
        UIpress.SetActive(false);
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
