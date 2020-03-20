using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject[] g;
    public GameObject opponent;
    private int length;
    // Start is called before the first frame update
    void Start()
    {
        length = g.Length;
    }

    // Update is called once per frame
    void Update()
    {
        int r;
        r = Random.Range(0, length+1);
        if (gameObject.tag=="Mystery")
        {
            if (r == length)
            {
                gameObject.transform.position = opponent.transform.position;
            }
            else
            {
                gameObject.transform.position = g[r].transform.position;
            }
            gameObject.tag = "NoPower";
        }

    }
}
