using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_sc : MonoBehaviour
{
    [SerializeField] private float rotateSpeed= 20.0f;
    [SerializeField] GameObject explosionPrefab;
    SpawnManager_sc spawnManager;
 
    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager == null){
            Debug.LogError("Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser"){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        spawnManager.StartSpawning();
        Destroy(this.gameObject);
        }
    }
}
