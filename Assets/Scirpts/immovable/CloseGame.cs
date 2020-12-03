using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    //数据库连接对象
    private SqliteConnection sqlikte;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;
    //数据库路径
    private string connectionStr;
    public GameObject choice;
    private bool first;
    private void Start()
    {
        //数据源路径
        connectionStr = "Data Source = " +
                        Application.streamingAssetsPath + "/GameJsonParse.sqlite";
        //实例化连接对象
        sqlikte = new SqliteConnection(connectionStr);

        //创建指令对象
        command = sqlikte.CreateCommand();
    }
    public void StartGame()
    {
        sqlikte.Open();
        command.CommandText = "Select FirstTime From FIrstGame";
        reader = command.ExecuteReader(); //读取数据
        first = Convert.ToBoolean(reader.GetValue(0));
        Debug.Log(Convert.ToBoolean(reader.GetValue(0)));
        reader.Close();
        if (first)
        {
            command.CommandText = "Update FIrstGame Set FirstTime=false";
            SceneManager.LoadScene(1);
            command.CommandText = "Updat CurrentLevel Set LevelNow =1";
        }
        else
        {
            choice.SetActive(true);
        }
        
        sqlikte.Close();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
