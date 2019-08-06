using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {


    private Image img;


	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHp (float val)
    {
        img.fillAmount = val;
    }

}
