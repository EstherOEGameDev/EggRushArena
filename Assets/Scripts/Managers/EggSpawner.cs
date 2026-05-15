using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    
    public GameObject eggPrefab;

    public int maxEggs=10;

    public float spawnInterval=2f;

    public Vector2 arenasizeZ= new Vector2(52f, 81.5f);

    public Vector2 arenaSizex= new Vector2(41,83.3f);

    private int currentEggs=0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEgg), 1,spawnInterval);
    }

    void SpawnEgg()
    {
        if(currentEggs >= maxEggs)
        return;


        Vector3 randomPos= new Vector3(Random.Range(-arenaSizex.x, arenaSizex.x), 0.5f, Random.Range(-arenasizeZ.x, arenasizeZ.y));

        Instantiate(eggPrefab, randomPos, Quaternion.identity);
        currentEggs++;
    }

    public void EggCollected()
    {
        currentEggs--;
    }
}
