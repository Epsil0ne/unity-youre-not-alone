using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceGO : MonoBehaviour
{
    public RessourceType resType;
    void Start()
    {
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
}

public enum RessourceType {Ship, Wood, Fruit, Iron };
