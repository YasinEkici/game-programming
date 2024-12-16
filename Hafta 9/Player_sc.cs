using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_sc : MonoBehaviour
{           
    [SerializeField] int score = 0;
    [SerializeField] public float speed = 3.5f;
     [SerializeField] float speedMultiplier = 2;
     [SerializeField] private bool isTripleShotActive = false;
    [SerializeField] private bool isSpeedBoostActive = false;
    [SerializeField] private bool isShieldActive = false;
    [SerializeField] private GameObject shieldVisualizer;
    [SerializeField] private GameObject tripleShotPrefab;
    [SerializeField] private GameObject rightEngine;
    [SerializeField] private GameObject leftEngine;

    [SerializeField] float fireRate = 0.5f;
    public GameObject laserPrefab;
    
    float nextFire = 0f;
    int lives = 3;
    SpawnManager_sc spawnManager_sc;
    UIManager_sc uiManager_sc;
    void Start()
    {
    // Küpü başlangıçta taşıma
    transform.position = new Vector3(-2, 0, 0);
    spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
    if(spawnManager_sc == null){
        Debug.LogError("Spawn_Manager oyun nesnesi bulunamadi");
    }
    uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
    if(uiManager_sc == null){
        Debug.LogError("UI Manager bulunamadi");
    }
    
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
            nextFire = Time.time + fireRate;
            if(isTripleShotActive == true){
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else{
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1.15f,0), Quaternion.identity);
            }

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

        public void Damage(){
            if(isShieldActive == true){
                isShieldActive = false;
                shieldVisualizer.SetActive(false);
                return;
            }

            lives--;
            if(lives == 2){
                leftEngine.SetActive(true);
            }
            else if(lives == 1){
                rightEngine.SetActive(true);
            }

            if(uiManager_sc != null){
            uiManager_sc.UpdateLivesIMG(lives);
            }
                       
            if(lives < 1){
                if (spawnManager_sc != null){
                spawnManager_sc.OnPlayerDeath();
                Destroy(this.gameObject);
                }
            }
        }

        public void TripleShotActive(){
            isTripleShotActive = true;
            StartCoroutine(TripleShotBonusDisableRoutine());
        }

        IEnumerator TripleShotBonusDisableRoutine(){
            yield return new WaitForSeconds(5.0f);
            isTripleShotActive = false;
        }

        public void SpeedBoostActive(){
            isSpeedBoostActive = true;
            speed *= speedMultiplier;
            StartCoroutine(SpeedBoostBonusDisableRoutine());
        }

        IEnumerator SpeedBoostBonusDisableRoutine(){
            yield return new WaitForSeconds(5.0f);
            isSpeedBoostActive = false;
            speed /= speedMultiplier;
        }

        public void ShieldBonusActive(){
            isShieldActive = true;
            StartCoroutine(ShieldBonusDisableRoutine());
            shieldVisualizer.SetActive(true);
        }

        IEnumerator ShieldBonusDisableRoutine(){
            yield return new WaitForSeconds(10.0f);
            isShieldActive = false;
            shieldVisualizer.SetActive(false);
        }

        public void UpdateScore(int points){
            score += points;
            if(uiManager_sc != null)
            {
                uiManager_sc.UpdateScoreTMP(score);
            }
            
        }
}