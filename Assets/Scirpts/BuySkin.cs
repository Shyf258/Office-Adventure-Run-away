using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;
public class BuySkin : MonoBehaviour
{
    private SqliteConnection sqlikte;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;
    //数据库路径
    private string connectionStr;
    //皮肤价格 后期更改值
    private int price;
    [HideInInspector]
    public int skinNum;
    public GameObject Buy;//购买对话框
    public GameObject noMoney;//钱不够买皮肤
    // Start is called before the first frame update
    //void Start()
    //{
    //    //数据源路径
    //    connectionStr = "Data Source = " +
    //                    Application.streamingAssetsPath +
    //                    "/GameJsonParse.sqlite";
    //    sqlikte = new SqliteConnection(connectionStr);
    //    command = sqlikte.CreateCommand();
    //    price = 1000;   //皮肤价格 后期进行更改
    //    skinNum = transform.parent.GetSiblingIndex() + 1;
    //}

    //// Update is called once per frame
    //public void Unlock()
    //{
    //  int coin =  Convert.ToInt32(GameObject.Find("Coins").transform.GetChild(3).GetComponent<Text>().text);
    //    if (coin>= price)
    //    {
    //        command.CommandText = "Update Skin Set activate = true Where =" + skinNum;
    //    }
    //    else
    //    {

    //    }
    //}

}
