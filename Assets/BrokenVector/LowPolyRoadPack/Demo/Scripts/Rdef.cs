using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rdef : MonoBehaviour
{
    public float speed;
    public float rotspeed;
    Rigidbody r;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = r.velocity.magnitude;
        rotspeed = r.angularVelocity.magnitude * Mathf.Rad2Deg;
        r.angularVelocity = new Vector3(0, Mathf.PI * 1, 0);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "NoPower")
        {
            col.gameObject.tag = "Defense";
            print("Hello");
        }
    }
}


