using UnityEngine;
using System;
using UnityEngine.UI;
using Mono.Data.Sqlite;



public class ChoiceJsonSelected : MonoBehaviour
{
    public GameObject level_open_button_prefabs;    

    private int a=1; //当前页面第一关
    private int level; //关卡
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
        //数据源路径
        connectionStr = "Data Source = " +
                        Application.streamingAssetsPath + "/GameJsonParse.sqlite";
        //实例化连接对象
        sqlikte = new SqliteConnection(connectionStr);
       
        //创建指令对象
        command = sqlikte.CreateCommand();
        ShowPass();
    }
    private void ShowPass()
    {
        //打开链接
        sqlikte.Open();
        for (int i = a; i < a+8; i++)
        {
            GameObject level_open_button = Instantiate(level_open_button_prefabs);
            //SQL语句，查询
            command.CommandText = "Select starnum From LevelMsg Where leveIndex="+i;
            reader = command.ExecuteReader(); //读取数据
            //显示第几关
            level_open_button.transform.GetChild(4).GetComponent<Text>().text =i.ToString();
            level = i;
            int starnum = Convert.ToInt32(reader.GetValue(0)); //有几颗星星
            reader.Close();            //关闭读取器
              //SQL语句，查询
             
            

            //根据获得星星的数量判断是否通关并亮了几颗星
            if (starnum == 0)
            {
                //GetComponent<Button>().enabled = false;
                level_open_button.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (starnum == 1)
            {
                //GetComponent<Button>().enabled = true;
                level_open_button.transform.GetChild(3).gameObject.SetActive(false);
                level_open_button.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (starnum == 2)
            {
                //GetComponent<Button>().enabled = true;
                level_open_button.transform.GetChild(3).gameObject.SetActive(false);
                level_open_button.transform.GetChild(0).gameObject.SetActive(true);
                level_open_button.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (starnum == 3)
            {
                //GetComponent<Button>().enabled = true;
                level_open_button.transform.GetChild(3).gameObject.SetActive(false);
                level_open_button.transform.GetChild(0).gameObject.SetActive(true);
                level_open_button.transform.GetChild(1).gameObject.SetActive(true);
                level_open_button.transform.GetChild(2).gameObject.SetActive(true);
            }
           
            //设置父子关系
            level_open_button.transform.SetParent(transform);
            level_open_button.transform.localScale = new Vector3(1, 1, 1);
            level_open_button.transform.localPosition = new Vector3(0, 0, 0);

            if (i == 1)
            {
                this.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
            }
            else
            {
                int b = i - 1;
                command.CommandText = "Select starnum From LevelMsg Where leveIndex=" + b;
                reader = command.ExecuteReader();
                int a = Convert.ToInt32(reader.GetValue(0));
                if (a > 0)
                {
                    this.transform.GetChild(i - 1).GetChild(3).gameObject.SetActive(false);
                }
            }
            reader.Close(); //关闭读取器

        }
        //关闭链接
        sqlikte.Close();
    }

}