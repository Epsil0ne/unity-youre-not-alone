using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceGO : MonoBehaviour
{
    public GameObject UIpressToGive;
    public RessourceType resType;
    void Start()
    {
        UIpressToGive.SetActive(false);
        GameManager.ressourcesList.Add(this);
    }


    private void OnDestroy()
    {
        GameManager.ressourcesList.Remove(this);
    }

    private void Update()
    {
        if (resType == RessourceType.Ship)
        {
            transform.Rotate(Vector3.up*100*Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {

       
            UIpressToGive.SetActive(true);
        

    }
    private void OnTriggerExit(Collider other)
    {
        UIpressToGive.SetActive(false);
    }
}

public enum RessourceType {Ship, Wood, Fruit, Iron };
