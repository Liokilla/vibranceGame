using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject[] waypoints;
    public int list = 0;

    public float mindist;
    public float speed;
    public float dist;

    public bool go = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position,waypoints[list].transform.position);
        if(go)
        {
            if(dist>mindist)
            {
                move();
            }
        }
        else if(dist<=mindist)
        {
            print("Hello");
            go = false;
            if(list+1==waypoints.Length)
            {
                list = 0;
            }
            else
            {
                list = list + 1;
            }
        }
    }
    public void move()
    {
        gameObject.transform.LookAt(waypoints[list].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
