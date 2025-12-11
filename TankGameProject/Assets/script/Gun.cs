using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rotgun;
    public GameObject gun;
    public float rotate;
    public int rotSpeed;
    public int power;
    public float attack;
    public GameObject gunprefab;
    public GameObject gunprefab2;
    private Transform gun_point;
    private Transform gun_point2;
    public float Destroy = 2.0f;

    void Start()
    {
        rotSpeed = 120;
        power = 3000;
        gun_point = GameObject.Find("gun_point").transform;
        gun_point2 = GameObject.Find("gun_point2").transform;
    }

    void Update()
    {
        rotate = rotSpeed * Time.deltaTime;
        rotgun = Input.GetAxis("gun_attack"); // 총 회전
        gun.transform.Rotate(Vector3.up * rotgun * rotate);

        if(Input.GetMouseButtonDown(1)){
            
            GameObject gun1 = Instantiate(gunprefab, gun_point.position, gun_point.rotation) as GameObject;
            Rigidbody gun_force = gun1.GetComponent<Rigidbody>();
            gun_force.AddForce(gun.transform.forward * power);
            Destroy(gun1,Destroy);
            
            //Fire();
        }
        if(Input.GetMouseButtonDown(1)){
            
            GameObject gun2 = Instantiate(gunprefab2, gun_point2.position, gun_point2.rotation) as GameObject;
            Rigidbody gun_force2 = gun2.GetComponent<Rigidbody>();
            gun_force2.AddForce(gun.transform.forward * power);
            Destroy(gun2,Destroy);
            
            //Fire2();
        }
    }
    /*
    void Fire()
    {
        CreateBullet();
    }

    void CreateBullet()
    {
        var bullet = ObjectPool1.GetObject();
        var direction = transform.forward;
        bullet.transform.position = firePos.position;
        bullet.Shoot(direction.normalized);
    }

    void Fire2()
    {
        CreateBullet2();
    }

    void CreateBullet2()
    {
        var bullet2 = ObjectPool1.GetObject();
        var direction2 = transform.forward;
        bullet2.transform.position = firePos2.position;
        bullet2.Shoot(direction.normalized);
    }*/

}
