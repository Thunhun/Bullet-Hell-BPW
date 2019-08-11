using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float xSpeed = 0;
    private float ySpeed = 0;
    public float maxSpeed = 10;
    public GameObject bullet;
    public GameObject Altbullet;
    public GameObject HitBox;
    public Transform schootPos;
    public Transform AltschootPos;
    private bool isShooting = false;
    private bool isShootingCircle = false;
    public float bps = 5;
    public float bpsc = 5;
    public int apc = 7;
    private Vector3 AltshootPos;
    public float bulletSpeed = 0.7f;
    public float AltbulletSpeed = 0.2f;
    public int bulletDamage = 1;
    public int AltbulletDamage = 2;


    void Start()
    {
        PoolManager.instance.CreatePool(bullet, 50);
        PoolManager.instance.CreatePool(Altbullet, 50);
        AltshootPos = transform.position;
        AltshootPos.y -= 5;
        isShootingCircle = true;
        StartCoroutine(shootingCircle());

    }


    void Update () {
        xSpeed = Input.GetAxis("Horizontal") * maxSpeed;
        ySpeed = Input.GetAxis("Vertical") * maxSpeed;
        transform.Translate(new Vector2(xSpeed, ySpeed));



        if (Input.GetKeyDown(KeyCode.Z))
        {
            isShooting = true;
            StartCoroutine(shooting());


        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isShooting = false;
            StopCoroutine(shooting());

        }

      
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxSpeed = maxSpeed / 2;
            HitBox.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxSpeed = maxSpeed * 2;
            HitBox.SetActive(false);
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
        FindObjectOfType<AudioManager>().Play("PlayerShooting");

    }

    IEnumerator shootingCircle()
    {
  
        yield return new WaitForSeconds(4 / bpsc);
        shootCircle();
        if (isShootingCircle)
        {
            StartCoroutine(shootingCircle());
        }
    }
    void shootCircle()
    {
        for (int i = 0; i < apc; i++)
        {
            GameObject cBullet = PoolManager.instance.ReuseObject(Altbullet, AltschootPos.position, AltschootPos.rotation);
            cBullet.GetComponent<LaserProjectile>().Spawn(AltbulletSpeed, AltbulletDamage);
            transform.Rotate(new Vector3(0, 0, 360 / apc));
        }
        transform.rotation = new Quaternion();
        FindObjectOfType<AudioManager>().Play("PlayerCircle");
    }

}
