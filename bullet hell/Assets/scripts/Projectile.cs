using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basic projectile class that the character shoots
/// </summary>
public class Projectile : PoolObject
{
    //speed
    [SerializeField]
    private float speed = 0.8f;
    //when it destroys itself
    [SerializeField]
    private float destroyTime = 3f;
    public int damage = 1;

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
    public void Spawn(float _speed = 0.8f, int _damage = 1)
    {
        damage = _damage;
        speed = _speed;
        StartCoroutine(Destroying());

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy();
    }
    //when it hits something.
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.GetComponent<Projectile>())
        {
            if (col.gameObject.GetComponent<Health>())
            {
                Debug.Log("PUSH BAACCCKKK");
                col.gameObject.GetComponent<Health>().Damage(damage);
            }
            StopAllCoroutines();
            Destroy();
        }
        
    }
}
