using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Wincondition : MonoBehaviour
{
    // Start is called before the first frame update
    public int laps;
    private int lc1,lc2;
    void Start()
    {
        laps = 1;
        lc1 = 0;
        lc2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="NoPower1")
        {
            lc1++;
        }
        if(lc1==laps)
        {
            SceneManager.LoadScene("Player1wins");
        }
        if (col.gameObject.tag == "NoPower2")
        {
            lc2++;
        }
        if (lc2 == laps)
        {
            SceneManager.LoadScene("Player2wins");
        }
    }
}
