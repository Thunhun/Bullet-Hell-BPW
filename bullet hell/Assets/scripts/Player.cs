using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float xSpeed = 0;
    private float ySpeed = 0;
    public float maxSpeed = 10;
    public GameObject bullet;
    public Transform schootPos;
    private bool isShooting = false;
    public float bps = 5;

    public float bulletSpeed = 0.7f;
    public int bulletDamage = 1;


    void Start()
    {
        PoolManager.instance.CreatePool(bullet, 50);


    }

    
    void Update () {
        xSpeed = Input.GetAxis("Horizontal") * maxSpeed;
        ySpeed = Input.GetAxis("Vertical") * maxSpeed;
        transform.Translate(new Vector2(xSpeed, ySpeed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShooting = true;
            StartCoroutine(shooting());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
            StopAllCoroutines();
        }


    }
    void LateUpdate()
    {
        Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, lowerLeft.x, upperRight.x);
        v3.y = Mathf.Clamp(v3.y, lowerLeft.y, upperRight.y);
        transform.position = v3;
    }


    IEnumerator shooting() 
    {
        shoot();
        yield return new WaitForSeconds(1 / bps);
        if(isShooting)
        {
            StartCoroutine(shooting());
        }

    }

    void shoot()
    {
        GameObject cBullet = PoolManager.instance.ReuseObject(bullet, schootPos.position, schootPos.rotation);
        cBullet.GetComponent<Projectile>().Spawn(bulletSpeed, bulletDamage);

    }

}
