using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
    private Player_sc player;
    private Animator anim;

    void Start()
    {
        Player_sc player = GameObject.Find("Player").GetComponent<Player_sc>(); 
        anim = GetComponent<Animator>();

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
            anim.SetTrigger("OnEnemyDeath");
            speed = 0f;
            Destroy(this.gameObject, 2.8f);
        }
        else if (other.tag == "Laser"){
            Destroy(other.gameObject);
            if(player != null){
                player.UpdateScore(10);
            }
            anim.SetTrigger("OnEnemyDeath");
            speed = 0f;
            Destroy(this.gameObject, 2.8f);
        }
    }
    
    }
