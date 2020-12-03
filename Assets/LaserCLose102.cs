using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCLose102 : MonoBehaviour
{
    [HideInInspector]
    public bool NoTable =false;
    public GameObject laser;
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
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        if (other.name!= "WashTable")
        {
            NoTable = true;
        }
        laser.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        NoTable = false;
        laser.gameObject.SetActive(true);
    }
}
