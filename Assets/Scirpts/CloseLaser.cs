using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLaser : MonoBehaviour
{
    public GameObject laser;
    [HideInInspector]
    public bool laserOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag==GameConst.PLAYER)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                laserOn = false;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                //关闭激光
                for (int i = 0; i <4; i++)
                {
                    laser.transform.GetChild(i).GetComponent<Beam>().pauseDelay = 9999999999;
                    laser.transform.GetChild(i).GetComponent<Beam>().beamDuration = 0;
                }
            }
        }
    }
}
