using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
   
   public GameObject PassDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("得到钥匙");
            other.transform.GetComponent<PlayerMovement>().getKey = true;
            this.gameObject.SetActive(false);
            if (PassDoor)
            {
                GameObject.Find("PassDoor").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("PassDoor").transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
