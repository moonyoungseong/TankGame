using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : MonoBehaviour
{
    public int moveSpeed;
    public float move;
    public float moveVertical;

    public int rotSpeed;
    public float rotate;
    public float rotHorizon;

    public float rotTurret;
    public GameObject turret;
    public GameObject gun;

    public int power;
    public GameObject bulletPrefab;
    private Transform spPoint;
    public float DestroyTime = 2.0f;
    
    void Start()
    {
        moveSpeed = 5;
        rotSpeed = 120;
        power = 600;
        spPoint = GameObject.Find("Tank_spPoint").transform;
    }

    void Update()
    {
        float keyGun = Input.GetAxis("Mouse ScrollWheel");
        gun.transform.Rotate(eulers:Vector3.right * keyGun * 4);

        Vector3 ang = gun.transform.eulerAngles; // 포신 상하 회전 제한
        if (ang.x >180){
            ang.x -= 360;
        }
        ang.x = Mathf.Clamp(value:ang.x, min:-15, max:5);
        gun.transform.eulerAngles = ang;

        move = moveSpeed * Time.deltaTime;
        rotate = rotSpeed * Time.deltaTime;

        moveVertical = Input.GetAxis("Vertical");
        rotHorizon = Input.GetAxis("Horizontal");
        rotTurret = Input.GetAxis("Window Shake X");

        transform.Translate(Vector3.forward * move *moveVertical);
        transform.Rotate(new Vector3(0.0f, rotate * rotHorizon, 0.0f));
        turret.transform.Rotate(Vector3.up *rotTurret *rotate);

        if(Input.GetMouseButtonDown(0)){
            GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject;
            Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>();
            bulletAddforce.AddForce(turret.transform.forward * power);
            Destroy(bullet, DestroyTime);
        }
    }
}

