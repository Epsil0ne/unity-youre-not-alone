using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceGO : MonoBehaviour
{
    public GameObject UIpressToGive;
    public RessourceType resType;
    public bool isFruitOnCactus = false;


    void Start()
    {
        UIpressToGive.SetActive(false);
        GameManager.ressourcesList.Add(this);
    }

    void OnDestroy()
    {
        GameManager.ressourcesList.Remove(this);
    }

    void Update()
    {
        if (resType == RessourceType.Ship)
        {
            transform.Rotate(100 * Time.deltaTime * Vector3.up);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        UIpressToGive.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        UIpressToGive.SetActive(false);
    }

    internal void Grab()
    {
        GetComponent<Collider>().enabled = false;
        UIpressToGive.SetActive(false);
    }

    internal void Drop()
    {
        GetComponent<Collider>().enabled = true;
        UIpressToGive.SetActive(true);
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
    }
}

public enum RessourceType {Ship, Wood, Fruit, Iron };
