using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRay : MonoBehaviour
{
    int count = 0;
    public Transform Object;
    public GameObject Bullet;
    public float bulletSpeed = 5f;
    //public float offset = 5f;

    float ycomponent;
    float xcomponent;
    float lycomponent;
    float lxcomponent;
    float rycomponent;
    float rxcomponent;

    // Start is called before the first frame update
    void Start()
    {
        ycomponent = Mathf.Sin((transform.eulerAngles.z - 90) * Mathf.PI / 180);
        xcomponent = Mathf.Cos((transform.eulerAngles.z - 90) * Mathf.PI / 180);
        lycomponent = Mathf.Sin((transform.eulerAngles.z - 135) * Mathf.PI / 180);
        lxcomponent = Mathf.Cos((transform.eulerAngles.z - 135) * Mathf.PI / 180);
        rycomponent = Mathf.Sin((transform.eulerAngles.z - 45) * Mathf.PI / 180);
        rxcomponent = Mathf.Cos((transform.eulerAngles.z - 45) * Mathf.PI / 180);
        StartCoroutine(ExampleCoroutine1());
    }
    IEnumerator ExampleCoroutine1()
    {
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {   
        yield return new WaitForSeconds(1.0f);
        count ++;
        //if(count % 5 == 0)
        //{  
            GameObject clone  = Instantiate(Bullet);
            clone.transform.position = transform.position;
            clone.SetActive(true);
            if ((count % 4 == 1) || (count % 4 == 3))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(xcomponent, ycomponent).normalized * bulletSpeed;
            }
            else if (count % 4 == 2)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(rxcomponent, rycomponent).normalized * bulletSpeed;
            }
            else
            {    
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(lxcomponent, lycomponent ).normalized * bulletSpeed;   
            }
        //}
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(ExampleCoroutine());
    }
}
