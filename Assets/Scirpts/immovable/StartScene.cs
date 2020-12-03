using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
public class StartScene : MonoBehaviour
{

    //数据库连接对象
    private SqliteConnection con;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;

    private string connectionStr;

    //当前选择的皮肤
    private int skin;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        connectionStr = "Data Source = " +
                     Application.streamingAssetsPath +
                     "/GameJsonParse.sqlite";

        //实例化连接对象
        con = new SqliteConnection(connectionStr);
        //打开连接
        con.Open();
        //创建指令对象
        command = con.CreateCommand();
        command.CommandText = "Select num From People_Choose"; //读取当前选择的皮肤
        reader = command.ExecuteReader();
        skin = Convert.ToInt32(reader.GetValue(0));
        reader.Close();
        player.transform.GetChild(skin).gameObject.SetActive(true); //设置皮肤
        con.Close();
    }

    // Update is called once per frame
   
}
