using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject slime;
    [SerializeField]
    private GameObject fairy;
    [SerializeField]
    private GameObject vampireTulip;
    [SerializeField]
    private GameObject genie;

    [SerializeField]
    private float slimeInterval = 3.5f;
    [SerializeField]
    private float fairyInterval = 5f;
    [SerializeField]
    private float vampireTulipInterval = 7f;
    [SerializeField]
    private float genieInterval = 10f;

    void Start()
    {
        StartCoroutine(spawnEnemy(slimeInterval, slime));
        StartCoroutine(spawnEnemy(fairyInterval, fairy));
        StartCoroutine(spawnEnemy(vampireTulipInterval, vampireTulip));
        StartCoroutine(spawnEnemy(genieInterval, genie));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0f), Quaternion.identity);
        newEnemy.transform.parent = transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        EnemyDamage enemyDamageScript = newEnemy.GetComponent<EnemyDamage>();
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        enemyDamageScript.player = playerHealth;

        AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
        destinationSetter.target = player.transform;
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
