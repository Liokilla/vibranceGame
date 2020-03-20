using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject g;
    public Transform t;
    public bool spawn;
    //private float time;
    void Start()
    {
        spawn = false;
    }

    // Update is called once per frame
   /* void Update()
    {
        if (spawn == false)
        {
            if (Time.deltaTime == time + 5 || time==0)
            {
                float r = (Random.Range(1, n));
                Instantiate(g[(int)r], gameObject.transform.position, Quaternion.Euler(0, 0, 90));

                spawn = true;
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        Instantiate(g, t.position, Quaternion.Euler(0, 0, 90));
        //spawn = false;
        //time = Time.deltaTime;
        print("HEllo");
        if (/*other.gameObject.tag=="Car" &&  */spawn==false)
        {
            print("In here");
            Instantiate(g, t.position, Quaternion.Euler(0, 0, 90));
            spawn = true;
        }

    }
}
