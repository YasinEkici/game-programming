using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_s : MonoBehaviour
{
    public float speed = 3.5f;
    void Start()
    {
    // Küpü başlangıçta taşıma
    transform.position = new Vector3(-2, 0, 0);
    }   


    // Update is called once per frame
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
        float verticalInput = Input.GetAxis("Vertical"); // Dikey eksen girişi (yukarı-aşağı tuşları)
        float horizontalInput = Input.GetAxis("Horizontal"); // Yatay eksen girişi (sol-sağ tuşları)
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * horizontalInput); 
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed * verticalInput); 
    }
}