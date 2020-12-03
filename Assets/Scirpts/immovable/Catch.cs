using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    //用钥匙去开关门
    GameObject b;
    GameObject a;
    private void Awake()
    {
       b = GameObject.Find("OpenDoor").transform.GetChild(0).gameObject;
       a = GameObject.Find("OpenDoor").transform.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player"&&Input.GetKeyDown(KeyCode.Q))
        {
            b.SetActive(false);
            a.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
