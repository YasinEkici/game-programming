using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    float speed = 3f;
    [SerializeField] int bonusID;
    [SerializeField] AudioClip audioClip;
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
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            if(player != null){
                switch(bonusID){
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldBonusActive();
                        break;
                    case 3:         
                        Debug.Log("Default value");
                        break;      
            }   
            }
            Destroy(this.gameObject);
        }
    }

}