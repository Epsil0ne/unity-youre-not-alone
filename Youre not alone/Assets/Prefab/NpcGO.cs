using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcGO : MonoBehaviour
{
    private int currentLike = 0;
    private int maxLike = 3;

    private AudioSource source;
    private AudioSource dialogue_source;


    public int id;
    public string[] QuestTexts = new string[4];
    public RessourceType[] QuestItem = new RessourceType[3];
    public AudioClip[] dialogue_clip;

    [Space]
    [Header("[References GO]")]
    public TMP_Text DialogText;
    public Image reactionGood;
    public Image reactionBad;
    public Image UIHearth;
    public GameObject UIpressToGive;
    public Transform SpawnPoint;
    public GameObject particleHit;

    [Space]
    [Header("[References folder]")]
    public GameObject ShipPiecePrefab;
    public AudioClip audio_drop_item;
    public AudioClip audio_happy;
    public AudioClip audio_sad;
    public AudioClip[] audio_hammer;
    public AudioSource Hammer_source;


    private void Start()
    {
        UIpressToGive.SetActive(false);
        UIHearth.fillAmount = (float)currentLike / maxLike;
        DialogText.text = QuestTexts[currentLike];
        source = GetComponent<AudioSource>();
        dialogue_source = GetComponent<AudioSource>();

        reactionGood.enabled = false;
        reactionBad.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.player.itemInHand != null && GameManager.player.itemInHand.resType != RessourceType.Ship)
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
        InvokeRepeating("PlayHammerSound",  0,  1);

    }

    private void PlayHammerSound()
    {
        Hammer_source.clip = audio_hammer[UnityEngine.Random.Range(0, audio_hammer.Length)];
        Hammer_source.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && UIpressToGive.activeInHierarchy)

        {
            if (GameManager.player.itemInHand.resType == QuestItem[currentLike])
            {
                GameManager.player.ItemIsGiven();
                currentLike += 1;
                source.clip = audio_drop_item;
                source.Play();
                UIHearth.fillAmount = (float)currentLike / maxLike;
                UIpressToGive.SetActive(false);
                Instantiate(ShipPiecePrefab, SpawnPoint.position, SpawnPoint.rotation);

                DialogText.text = QuestTexts[currentLike];

                if (currentLike == maxLike)
                {
                    BeginHelping();
                    dialogue_source.clip = dialogue_clip[UnityEngine.Random.Range(0, dialogue_clip.Length)];
                    dialogue_source.Play();
                }
                else
                {
                    StartCoroutine(GoodReaction());
                }
            }
            else
            {
                StartCoroutine(BadReaction());
            }
        }
    }

    private IEnumerator GoodReaction()
    {
        DialogText.transform.parent.gameObject.SetActive(false);
        reactionGood.enabled = true;

        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = false;
        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = true;
        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = false;

        source.clip = audio_happy;
        source.Play();
        
        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = true;
        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = false;
        yield return new WaitForSeconds(0.3f);
        reactionGood.preserveAspect = true;

        reactionGood.enabled = false;
        DialogText.transform.parent.gameObject.SetActive(true);

        dialogue_source.clip = dialogue_clip[UnityEngine.Random.Range(0, dialogue_clip.Length)];
        dialogue_source.Play();
    }

    private IEnumerator BadReaction()
    {
        DialogText.transform.parent.gameObject.SetActive(false);
        reactionBad.enabled = true;

        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = false;
        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = true;
        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = false;

        source.clip = audio_sad;
        source.Play();

        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = true;
        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = false;
        yield return new WaitForSeconds(0.3f);
        reactionBad.preserveAspect = true;

        reactionBad.enabled = false;
        DialogText.transform.parent.gameObject.SetActive(true);
    }
}