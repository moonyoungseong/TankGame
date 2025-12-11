using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_bullet : MonoBehaviour
{
    public int power = 15000;
    public float DestroyMan2 = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "soldier"){
            Destroy(col.gameObject);
        }
    }
}
