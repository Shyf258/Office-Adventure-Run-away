using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCControl : MonoBehaviour
{
    public string ChatName;

    private bool canChat = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canChat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            canChat = false;
        }   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            say();
        }
        
    }

    //对话
    void say()
    {
        if (canChat)
        {
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            //对话是否存在
            if (flowChart.HasBlock(ChatName))
            {
                //执行对话
                flowChart.ExecuteBlock(ChatName);
            }
        }
    }
}
