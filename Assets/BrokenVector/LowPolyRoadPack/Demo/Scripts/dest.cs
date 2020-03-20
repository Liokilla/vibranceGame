using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dest : MonoBehaviour
{
    // Start is called before the first frame update
    private bool invin;
    private bool timer;
    public float a;
    public float b,c;

    private void Start()
    {
        invin = false;
        timer = false;
        a = 0;
    }
    private void Update()
    {
        c=Time.fixedTime;
        if(Input.GetMouseButton(1) && gameObject.tag=="Offence")
        {
            invin = true;
            timer = true;
            a = Time.fixedTime;
            b = a + 10;
            gameObject.tag = "NoPower";
            print("Dest Start");
        }
        if(timer==true)
        {
            if(Time.fixedTime==b)
            {
                invin = false;
                timer = false;
                print("Dest end");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (invin == true && collision.gameObject.tag=="NPC")
            Destroy(collision.gameObject);
    }
}
