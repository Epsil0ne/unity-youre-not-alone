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

    //  public Image UIpieces;


    private void Start()
    {
        UIPieces.fillAmount = (float)currentPieces / maxPieces;
        UIHelp.fillAmount = (float)currentHelp/maxHelp;
        GameManager.ship = this;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger ship");
        if (GameManager.player.itemInHand != null && GameManager.player.itemInHand.resType == RessourceType.Ship)
        {
            GameManager.player.ItemIsGiven();
            currentPieces += 1;
            UIPieces.fillAmount = (float)currentPieces/maxPieces;
        }

    }
    private void OnDestroy()
    {
        GameManager.ship = null;
    }


}
