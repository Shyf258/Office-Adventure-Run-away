using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private float gameTime = 0; //游戏时间
    //public int hour;//小时
    private int min; //分钟
    private int sec;//秒
    private float timer;// 计时，每帧记录
    private void OnTriggerStay(Collider other)
    {
        if (other.tag==GameConst.PLAYER)
        {
            gameTime += Time.deltaTime;
            sec = (int)gameTime;
           
            if (sec >30)
            {
              GameObject.Find("pass").GetComponent<Passlift>().condition3 = true;
            }
        }
       
    }
}
