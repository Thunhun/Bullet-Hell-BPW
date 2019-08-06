using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public GameObject bullet;
    public Transform schootPos;
    public int apc = 32;
    public float bps = 1;
    public float bulletSpeed = 0.7f;
    public int bulletDamage = 1;

    void Start () {
        PoolManager.instance.CreatePool(bullet, 50);
        StartCoroutine(shooting());

    }
	

	void Update () {
		
	}

    IEnumerator shooting()
    {
        shootCircle();
        yield return new WaitForSeconds(1 / bps);

        StartCoroutine(shooting());

    }

        void shootCircle()
    {
        for (int i = 0; i < apc; i++)
        {
            GameObject cBullet = PoolManager.instance.ReuseObject(bullet, schootPos.position, schootPos.rotation);
            cBullet.GetComponent<Projectile>().Spawn(bulletSpeed, bulletDamage);
            transform.Rotate(new Vector3(0, 0, 360 / apc));
        }
        transform.rotation = new Quaternion();
    }

}
