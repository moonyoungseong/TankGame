using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank_Bullet : MonoBehaviour
{
    public int power = 15000;
    public float DestroyMan = 2.0f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "soldier"){
            Destroy(col.gameObject, DestroyMan);
            Score.attack++;
                if(Score.attack == 30){
                    SceneManager.LoadScene("WinScene");
            }
        }
    }
}