using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basic projectile class that the character shoots
/// </summary>
public class LaserProjectile: PoolObject
{
    //speed
    [SerializeField]
    private float speed = 0.8f;
    //when it destroys itself
    [SerializeField]
    private float destroyTime = 3f;
    public int damage = 1;
    public bool fromEnemy = false;
    public void FixedUpdate()
    {
        //goes forward with speed!
        transform.Translate(Vector3.up * speed);

        //probably changed later?
        //Destroy(this.gameObject, destroyTime);
    }

    public override void OnObjectReuse()
    {
    }
    public override void Destroy()
    {
        base.Destroy();
    }
    public void Spawn(float _speed = 0.8f, int _damage = 1, bool _fromEnemy = false)
    {
        damage = _damage;
        speed = _speed;
        fromEnemy = _fromEnemy;
        StartCoroutine(Destroying());

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy();
    }
    //when it hits something.
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.GetComponent<Projectile>())
        {
            if (col.gameObject.GetComponent<Health>())
            {
                //.Log("PUSH BAACCCKKK");
                if ((col.gameObject.GetComponent<Player>() && fromEnemy) || (col.gameObject.GetComponent<Enemy>() && !fromEnemy))
                {
                    col.gameObject.GetComponent<Health>().Damage(damage);
                    StopAllCoroutines();
                   
                }
            }

        }
        
    }
}
