using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private int Hp;
    public int maxHp = 5;
    public Healthbar healthbar;

	void Start () {
        Hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage(int DamageValue)
    {
        Hp -= DamageValue;
        if (healthbar != null)
        {
            healthbar.UpdateHp( (float)Hp / (float)maxHp);
        }

        if (Hp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }


}
