using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject enemyContainer;
    [SerializeField]
    GameObject tripleShotBonusPrefab;
    bool stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine(){
        while(stopSpawning == false){
            Vector3 position = new Vector3(Random.Range(-9.4f, 9.4f), 7, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnBonusRoutine(){
        while(stopSpawning == false){
            Vector3 position = new Vector3(Random.Range(-9.8f, 9.8f), 7.4f, 0);
            Instantiate(tripleShotBonusPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }

    public void OnPlayerDeath(){
        stopSpawning = true;
    }
}
