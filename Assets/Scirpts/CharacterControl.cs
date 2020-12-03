using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Mono.Data.Sqlite;

[Serializable]
public class Character
{
    public int gold;
    public int diamond;
}

public class CharacterControl : MonoBehaviour
{
    ////Json文本
    //public TextAsset jsonText;
    //拖入金币对象
    public GameObject character_gold;
    //拖入钻石对象
    public GameObject character_diamond;

    //数据库连接对象
    private SqliteConnection sqlikte;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;
    //数据库路径
    private string connectionStr;
    private void Start()
    {
        //Character data = JsonUtility.FromJson<Character>(jsonText.text);
        //数据源路径
        connectionStr = "Data Source = " +
                        Application.streamingAssetsPath + "/GameJsonParse.sqlite";
        //实例化连接对象
        sqlikte = new SqliteConnection(connectionStr);
        //打开链接
        sqlikte.Open();
        //创建指令对象
        command = sqlikte.CreateCommand();
        //SQL语句，查询
        command.CommandText = "Select num From Gold";
        //执行SQL语句，并返回所有查询到的结果到读取器
        reader = command.ExecuteReader();
        //读取数据 
        //reader.Read();//读取下一行数据，如果没有下一行，返回false,否则返回true;
        string a = Convert.ToString( reader.GetValue(0));
        character_gold.transform.GetChild(3).GetComponent<Text>().text = Convert.ToString(a);
        //关闭读取器
        reader.Close();
        command.CommandText = "Select num From Gems";
        //执行SQL语句，并返回所有查询到的结果到读取器
        reader = command.ExecuteReader();
        string b = Convert.ToString(reader.GetValue(0));
        character_diamond.transform.GetChild(3).GetComponent<Text>().text = Convert.ToString(b);
        //关闭连接
        sqlikte.Close();
    }
    
}
