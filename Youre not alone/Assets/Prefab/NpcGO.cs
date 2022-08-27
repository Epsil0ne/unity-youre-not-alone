using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcGO : MonoBehaviour
{
    public int id;
    public GameObject UIpressToGive;
    public Image UIHearth;
    private int currentLike = 0;
    private int maxLike = 3;
    public Transform SpawnPoint;
    public GameObject ShipPiecePrefab;
    public string[] QuestTexts = new string[4];
    public RessourceType[] QuestItem = new RessourceType[3];
    public TMP_Text DialogText;
    public GameObject particleHit;
    public AudioClip audio_drop_item;
    private AudioSource source;

    private void Start()
    {
        UIpressToGive.SetActive(false);
        UIHearth.fillAmount = (float)currentLike / maxLike;
        DialogText.text = QuestTexts[currentLike];
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (GameManager.player.itemInHand!=null && GameManager.player.itemInHand.resType != RessourceType.Ship)
        {
            UIpressToGive.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        UIpressToGive.SetActive(false);
    }
    public void BeginHelping()
    {
        transform.SetPositionAndRotation(
            GameManager.ship.spawnPoint[id].position, 
            GameManager.ship.spawnPoint[id].rotation);

        GameManager.ship.HelpAdded();

        particleHit.SetActive(true);
        
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && UIpressToGive.activeInHierarchy 
            && GameManager.player.itemInHand.resType == QuestItem[currentLike])
        {
            GameManager.player.ItemIsGiven();
            currentLike += 1;
            source.clip = audio_drop_item;
            source.Play();
            UIHearth.fillAmount = (float)currentLike/maxLike;
            UIpressToGive.SetActive(false);

            Instantiate(ShipPiecePrefab, SpawnPoint.position, SpawnPoint.rotation);
            DialogText.text = QuestTexts[currentLike];
            if (currentLike == maxLike)
            {
                BeginHelping();
               
            }         
        }
    }
}
