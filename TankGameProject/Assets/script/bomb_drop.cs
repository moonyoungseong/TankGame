using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bomb_drop : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y <1.0f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Tank"){
            Score.Hit++;
            if(Score.Hit == 2){
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
}
