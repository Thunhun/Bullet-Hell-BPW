using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button Text;

    public Animator ani;
    public Canvas yourcanvas;



    void Start()
    {
        Text = Text.GetComponent<Button>();
        ani.enabled = false;
        yourcanvas.enabled = true;
    }


    public void Press()

    {
        Text.enabled = true;

        ani.enabled = true;


    }
}