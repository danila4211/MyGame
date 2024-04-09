using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] obstacleprefabs;
    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTimer = 2f;

    public float Speed = 1f;

    private float TimeUntilObstacleSpawn;

    private void Update()
    {
        if (ScoreScript.instance.isPlaying)
        {
            SpawnLoop();
        }
    }
    private void Start()
    {
        ScoreScript.instance.gameover.AddListener(Clear);
    }
    private void SpawnLoop()
    {
        TimeUntilObstacleSpawn += Time.deltaTime;
        if (TimeUntilObstacleSpawn >= obstacleSpawnTimer)
        {
            Spawn();
            TimeUntilObstacleSpawn = 0f;
        }
    }
    private void Clear()
    {
        foreach (Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }
    private void Spawn()
    {
        GameObject ObstacleSpawn = obstacleprefabs[Random.Range(0, obstacleprefabs.Length)];
        GameObject spawnedObstacle = Instantiate(ObstacleSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent= obstacleParent;
        Rigidbody2D ObstacleRb = spawnedObstacle.GetComponent<Rigidbody2D>();
        ObstacleRb.velocity = Vector2.left * Speed;
    }
}
