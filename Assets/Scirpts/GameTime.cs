using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{

    //判断第一关第二颗星的条件
    [HideInInspector]
    public float gameTime = 0; //游戏时间
    //public int hour;//小时
    [HideInInspector]
    public int min; //分钟
    [HideInInspector]
    public int sec;//秒
    [HideInInspector]
    public float timer;// 计时，每帧记录
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        sec = (int)gameTime;
        if (sec > 59f)
        {
            sec = (int)(gameTime - (min * 60));
        }
        min = (int)(gameTime / 60);
    }
    }

