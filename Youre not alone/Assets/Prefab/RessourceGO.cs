using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceGO : MonoBehaviour
{
    
    void Start()
    {
        GameManager.ressourcesList.Add(this);
    }


    private void OnDestroy()
    {
        GameManager.ressourcesList.Remove(this);
    }
}
