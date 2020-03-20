using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tele : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("NPC"))
        {
            col.transform.position = g.transform.position;
        }
    }
}
