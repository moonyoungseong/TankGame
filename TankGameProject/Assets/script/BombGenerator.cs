using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bombPrefab;
    float span = 0.1f; // 생성이 되는 주기
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta >this.span){
            this.delta = 0;
            GameObject item = Instantiate(bombPrefab) as GameObject;
            float x = Random.Range(-190,200);
            float z = Random.Range(-210,450);
            item.transform.position = new Vector3(x,100,z);
        }
    }
}
