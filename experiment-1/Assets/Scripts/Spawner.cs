using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnTransform;
    public ForceAmount forceAmount;
    public float fAmount;

    public AudioSource audioSource;
    public AudioClip ballSpawnSFX;
    void Start()
    {
        SetForceAmount();
        StartCoroutine(PlayAudio());
        Debug.Log(SpawnTransform.position);
    }

    public IEnumerator PlayAudio()
    {
        audioSource.PlayOneShot(ballSpawnSFX);
        yield return new WaitForSeconds(.25f);
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        
        Instantiate(BallPrefab,SpawnTransform.position, Quaternion.identity, SpawnTransform);
        yield return new WaitForSeconds(2f);
        StartCoroutine(PlayAudio());
    }

    public void SetForceAmount()
    {
        int i = Random.Range(1, 5);

        switch (i)
        {
            case 1:
                forceAmount.XandZAmount = new Vector2(fAmount, 0);
                break;
            case 2:
                forceAmount.XandZAmount = new Vector2(-fAmount, 0);
                break;
            case 3:
                forceAmount.XandZAmount = new Vector2(0, fAmount);
                break;
            case 4:
                forceAmount.XandZAmount = new Vector2(0, -fAmount);
                break;
        }
    }
}
