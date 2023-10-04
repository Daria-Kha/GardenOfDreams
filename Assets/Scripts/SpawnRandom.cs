using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject monsterPrefab; 
    public int numberOfMonsters = 3;
    public Transform[] spawnPoints;

    private void Start()
    {
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        var points = new HashSet<int>();
        for (var i = 0; i < numberOfMonsters; i++)
        {
            int randomPosition;
            do
            {
                randomPosition = Random.Range(0, spawnPoints.Length);
            } while (points.Contains(randomPosition));
            
            points.Add(randomPosition);
            Instantiate(monsterPrefab, spawnPoints[randomPosition].position, Quaternion.identity);
        }
    }
}