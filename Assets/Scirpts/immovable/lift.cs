using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{ //电梯开门动画
    private Animator a1;
    int a =0;
    // Start is called before the first frame update
    void Start()
    {
        a1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //做判断 如果玩家带着钥匙进入触发器
        if (other.tag == "Player" && GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().getKey)
        {
            a1.SetBool("Key", true);
            a1.SetBool("Away", false);
            if (a==1)
            {
              GameObject.Find("pass").GetComponent<Passlift>().condition3 = false;
            }
            else
            {
                GameObject.Find("pass").GetComponent<Passlift>().condition3 = true;
            }

            
        }
        //如果NPC进入触发器
        //对话之后的NPC 从这里消失
        if (other.tag == "NPC")
        {
            a = 1;
            other.gameObject.SetActive(false);
           
        }



    }
    private void OnTriggerExit(Collider other)
    {
        //如果玩家进入触发器之后又出去， 电梯门自动关闭
        //如果玩家身上还有钥匙，之后可以再次打开电梯门
        if (other.tag == "Player" && GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().getKey)
        {
            a1.SetBool("Away", true);
        }
    }
}
