using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float Lifespan = 5.0f;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision){
        
        Destroy(this.gameObject);
            
        
    }
    void Start()
    {
        Destroy(this.gameObject, Lifespan);
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 7.0f);
    }
}
