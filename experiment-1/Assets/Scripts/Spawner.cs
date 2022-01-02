using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnTransform;
    public ForceAmount forceAmount;

    void Start()
    {
        SetForceAmount();
        StartCoroutine(Spawn());
        Debug.Log(SpawnTransform.position);
    }

    public IEnumerator Spawn()
    {
        Instantiate(BallPrefab,SpawnTransform.position, Quaternion.identity, SpawnTransform);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Spawn());
    }

    public void SetForceAmount()
    {
        int i = Random.Range(1, 5);

        switch (i)
        {
            case 1:
                forceAmount.XandZAmount = new Vector2(1.25f, 0);
                break;
            case 2:
                forceAmount.XandZAmount = new Vector2(-1.25f, 0);
                break;
            case 3:
                forceAmount.XandZAmount = new Vector2(0, 1.25f);
                break;
            case 4:
                forceAmount.XandZAmount = new Vector2(0, -1.25f);
                break;
        }
    }
}
