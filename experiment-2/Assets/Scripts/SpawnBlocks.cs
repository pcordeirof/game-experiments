using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject BlockPrefab;
    public int NumberOfBlocks;
    public GameObject InitialBlock;
    public GameObject FinalBlock;

    Vector2Int IniBPosition;
    Vector2Int FinBPosition;

    [HideInInspector]
    public Vector2Int[,] BlockPositions = new Vector2Int[10, 10];
    public List<GameObject> Blocks = new List<GameObject>();

    public GameObject BallUpObject;

    public void Start()
    {
        int ix = Random.Range(1, 10);
        int iy = Random.Range(1, 10);
        IniBPosition = new Vector2Int(ix, iy);

        int fx = Random.Range(1, 10);
        int fy = Random.Range(1, 10);
        FinBPosition = new Vector2Int(fx, fy);

        float distance = Vector2Int.Distance(IniBPosition, FinBPosition);
        Debug.Log("Distance: " + distance);
        while (distance < 5)
        {
            fx = Random.Range(1, 10);
            fy = Random.Range(1, 10);
            FinBPosition = new Vector2Int(fx, fy);
            distance = Vector2Int.Distance(IniBPosition, FinBPosition);
            Debug.Log("Distance: " + distance);
        }

        InitialBlock.transform.position = new Vector3(IniBPosition.x, IniBPosition.y, 0);
        FinalBlock.transform.position = new Vector3(FinBPosition.x, FinBPosition.y, 0);

        BlockPositions[ix, iy] = IniBPosition;
        BlockPositions[fx, fy] = FinBPosition;

        for (int i = 0; i < NumberOfBlocks; i++)
        {
            SpawnBlock();
        }

        SpawnBallUp();
    }

    public void SpawnBlock()
    {
        int x = Random.Range(1, 10);
        int y = Random.Range(1, 10);
        Vector2Int bPosition = new Vector2Int(x, y);

        while(BlockPositions[x,y] != Vector2Int.zero)
        {
            x = Random.Range(1, 10);
            y = Random.Range(1, 10);
            bPosition = new Vector2Int(x, y);
        }

        BlockPositions[x, y] = bPosition;
        GameObject block = Instantiate(BlockPrefab, new Vector3(bPosition.x, bPosition.y, 0), Quaternion.identity);
        Blocks.Add(block);
    }

    public void SpawnBallUp()
    {
        int x = Random.Range(1, 10);
        int y = Random.Range(1, 10);
        Vector2Int bPosition = new Vector2Int(x, y);

        while (BlockPositions[x, y] != Vector2Int.zero)
        {
            x = Random.Range(1, 10);
            y = Random.Range(1, 10);
            bPosition = new Vector2Int(x, y);
        }

        BallUpObject.SetActive(true);
        BallUpObject.transform.position = new Vector3(bPosition.x, bPosition.y, 0);
    }
}
