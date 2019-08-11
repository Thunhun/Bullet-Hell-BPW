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

    public enum EnemyState { Moving, Shooting, Idle }
    public EnemyState state;
    private bool isShooting = false;
    private Vector3 shootPos;
    public float moveSpeed = 0.3f;
    public AudioSource shoot;

    void Start () {
        PoolManager.instance.CreatePool(bullet, 50);

        shootPos = transform.position;
        shootPos.y -= 5;
        state = EnemyState.Moving;
    }


    // Update is called once per frame
    void Update()
    {
        ExecuteState();
    }

    private void ExecuteState()
    {
        switch (state)
        {
            case EnemyState.Shooting:
                if (!isShooting)
                {
                    isShooting = true;
                    StartCoroutine(shooting());
                }
                break;
            case EnemyState.Moving:
                moving();
                break;
        }
    }
    void moving()
    {
        if (Vector2.Distance(shootPos, transform.position) < 0.5f)
        {
            state = EnemyState.Shooting;

        }
        transform.Translate(new Vector2(0, -moveSpeed));

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
            cBullet.GetComponent<Projectile>().Spawn(bulletSpeed, bulletDamage, true);
            transform.Rotate(new Vector3(0, 0, 360 / apc));
        }
        transform.rotation = new Quaternion();
        shoot.Play();
    }

}
