using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
using UnityEngine.UI;




public class PeopleJudge : MonoBehaviour
{
    //数据库连接对象
    private SqliteConnection sqlite;
    //数据库指令对象
    private SqliteCommand command;
    //路径
    private string connectionStr;
    //查询这是第几个子对象
    private int num;
    //模型预设体
    public GameObject model;
    private void Awake()
    {
       
    }
    private void Start()
    {
        //数据源路径
        connectionStr = "Data Source = " +
                        Application.streamingAssetsPath +
                        "/GameJsonParse.sqlite";
        sqlite = new SqliteConnection(connectionStr);
        command = sqlite.CreateCommand();
        
        
       num = transform.GetSiblingIndex()+1;
    }

    private void Update()
    {
        if (GetComponent<Toggle>().isOn)
        {
            model.GetComponent<Animator>().SetBool("Choose", true);
        }
        else
        {
            model.GetComponent<Animator>().SetBool("Choose", false);
        }
    }
    public void ChangeSkin()
    {
        sqlite.Open();
        //a 为数据库语句
        string a = "Update People_Choose Set num =" + num.ToString();
        command.CommandText = a;
        command.ExecuteNonQuery(); //执行语句
        //关闭连接
        sqlite.Close();
       
        
    }
}
