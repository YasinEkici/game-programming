using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class Powerup_sc : MonoBehaviour
{
    float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -5.83f){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player_sc player = other.transform.GetComponent<Player_sc>();
            if(player != null){
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }
    }
}
