using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Sc : MonoBehaviour
{
    [SerializeField]
    float speed = 8.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(transform.position.y > 7f){
            Destroy(this.gameObject);
        }
    }
}
