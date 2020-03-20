using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
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
        //wwspeed = r.velocity.magnitude;
        //rotspeed = r.angularVelocity.magnitude * Mathf.Rad2Deg;
        r.angularVelocity = new Vector3(0, Mathf.PI * rotspeed, 0);
    }
}
