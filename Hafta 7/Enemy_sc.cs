using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -5.4f){
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 7f, 0);

        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player_sc player = other.transform.GetComponent<Player_sc>();
            if(player != null){
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    
    }
