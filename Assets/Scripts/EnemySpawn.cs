using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public List<GameObject> enemies;
    public int numberOfWaves = 3;
    public float intervalBetweenWaves = 5.0f;
    public float initialDelay = 0.5f;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnWaves());
            Destroy(gameObject, intervalBetweenWaves * numberOfWaves + initialDelay);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialDelay);
        
        for (int i = 0; i < numberOfWaves; i++)
        {
            EnemySpawner();
            yield return new WaitForSeconds(intervalBetweenWaves);
        }
    }

    private void EnemySpawner()
    {
        foreach (var enemy in enemies)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}


