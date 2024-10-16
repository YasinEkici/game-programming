using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_s : MonoBehaviour
{
    public float speed = 3.5f;
    public GameObject laserPrefab;
    float fireRate = 0.5f;
    float nextFire = 0f;
    void Start()
    {
    // Küpü başlangıçta taşıma
    transform.position = new Vector3(-2, 0, 0);
   
    }   

    /*void Update(){
        transform.Translate(Vector3.right); statik sağa ilerleme
    }
      
        void Update(){
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime); saniyeye göre düzenleme
    }
    
        void Update(){
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed); speed değişkenine göre ayarlama
    }
    */
        void Update(){ //x ve y eksen girişleri
        
        CalculateMovement();
        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            FireLaser();
        }
        
    }

        public void FireLaser(){
            Instantiate(laserPrefab,transform.position + new Vector3(0, 0.8f,0), Quaternion.identity);
            nextFire = Time.time + fireRate;

        }

        public void CalculateMovement(){
        float vertical = Input.GetAxis("Vertical"); // Dikey eksen girişi (yukarı-aşağı tuşları)
        float horizontal = Input.GetAxis("Horizontal"); // Yatay eksen girişi (sol-sağ tuşları)
        Vector3 direction =new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed);

        if(transform.position.y >= 0f){
            transform.position=new Vector3(transform.position.x,0,0);
        }

        else if(transform.position.y <= -3.9f){
            transform.position=new Vector3(transform.position.x,-3.9f,0);
        }

        if(transform.position.x >= 9.8f){
        transform.position=new Vector3(9.8f, transform.position.y, 0);
        }
        else if(transform.position.x <= -9.8f){
        transform.position=new Vector3(-9.8f, transform.position.y, 0); 
        }

        if(transform.position.x >= 9.8f){
        transform.position=new Vector3(-9.8f, transform.position.y, 0);    
        }
        else if(transform.position.x <= -9.8f){
        transform.position=new Vector3(9.8f, transform.position.y, 0);      
        }
}
}