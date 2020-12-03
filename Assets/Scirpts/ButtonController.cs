using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //数据库连接对象
    private SqliteConnection con;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;

    private string connectionStr;

    //预设体
    public GameObject information2_prefabs;

    private int levelNum;//当前是第几关
    private int leveNow;

    private void Start()
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
        levelNum = Convert.ToInt32(transform.GetChild(4).GetComponent<Text>().text);


        //如果未解锁则不能点击
    }
    private void Update()
    {
        if (transform.GetChild(3).GetComponent<Image>().IsActive())
        {
            GetComponent<Button>().enabled = false;
        }
    }
    public void LevelMes()
    {

        //levelNum = transform.GetSiblingIndex() + 1;
        //command.CommandText = "Update CurrentLevel Set LevelNow = " + levelNum;
        //command.ExecuteNonQuery(); //执行语句
        GameObject information2 = Instantiate(information2_prefabs);
        //SQL语句，查询
        command.CommandText = "Select condition1 From LevelMsg Where leveIndex=" + levelNum;
        reader = command.ExecuteReader();
        string a = Convert.ToString(reader.GetValue(0));
        reader.Close();
        command.CommandText = "Select condition2 From LevelMsg Where leveIndex=" + levelNum;
        reader = command.ExecuteReader();
        string b = Convert.ToString(reader.GetValue(0));
        reader.Close();
        command.CommandText = "Select condition3 From LevelMsg Where leveIndex=" + levelNum;
        reader = command.ExecuteReader();
        string c = Convert.ToString(reader.GetValue(0));
        reader.Close();
        //执行SQL语句，并返回所有查询到的结果到读取器
        
        //读取数据 
        //reader.Read();//读取下一行数据，如果没有下一行，返回false,否则返回true;
        //关闭读取器
        reader.Close();
        information2.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = a;
        information2.transform.GetChild(0).GetChild(6).GetComponent<Text>().text = b;
        information2.transform.GetChild(0).GetChild(9).GetComponent<Text>().text = c;
        information2.transform.SetParent(GameObject.Find("choice").transform, false);
    }

    public void ReadScene()
    {
        //connectionStr = "Data Source = " +
        //              Application.streamingAssetsPath +
        //              "/GameJsonParse.sqlite";

        ////实例化连接对象
        //con = new SqliteConnection(connectionStr);
        //con.Open();
        //创建指令对象
        //command = con.CreateCommand();
        //command.CommandText = "Select LevelNow From CurrentLevel";
        //command.ExecuteReader();
        //int a = Convert.ToInt32(reader.GetValue(0));
        //reader.Close();
        //con.Close();
        //SceneManager.LoadScene(a);


        leveNow = levelNum + 1;
        connectionStr = "Data Source = " +
                      Application.streamingAssetsPath +
                      "/GameJsonParse.sqlite";

        //实例化连接对象
        con = new SqliteConnection(connectionStr);
        con.Open();
        //创建指令对象
        command = con.CreateCommand();
        command.CommandText = "Update CurrentLevel Set LevelNow = " + leveNow;
        command.ExecuteNonQuery(); //执行语句
        con.Close();
        SceneManager.LoadScene(levelNum + 1);


    }
}
