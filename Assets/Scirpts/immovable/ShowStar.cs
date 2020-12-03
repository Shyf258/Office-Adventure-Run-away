using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowStar : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    Passlift pass;
    bool condition1;
    bool condition2;
    bool condition3;


    //数据库连接对象
    private SqliteConnection con;
    //数据库指令对象
    private SqliteCommand command;
    //数据库读取对象
    private SqliteDataReader reader;
    //数据库路径
    private string connectionStr;
    //第几个关卡
    private string tile;
    //第几关
    private int level;
    //获得了几个星星
    private int starNum ;
    //条件信息
    private string condition;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        starNum = 0;
        pass = GameObject.Find("pass").GetComponent<Passlift>();
        condition1 = pass.condition1;
        condition2 = pass.condition2;
        condition3 = pass.condition3;
        Invoke("Show", 1.5f);

        connectionStr = "Data Source = " +
                    Application.streamingAssetsPath +
                    "/GameJsonParse.sqlite";

        //实例化连接对象
        con = new SqliteConnection(connectionStr);
        //创建指令对象
        command = con.CreateCommand();
        //打开连接
        con.Open();
        //读取到的
        command.CommandText = "Select LevelNow From CurrentLevel";
        reader = command.ExecuteReader();
        tile = Convert.ToString(reader.GetValue(0));
        level = Convert.ToInt32(reader.GetValue(0));
        reader.Close();
        command.CommandText = "Select condition1 From LevelMsg Where leveIndex = " + level;
        reader = command.ExecuteReader();
        condition = Convert.ToString(reader.GetValue(0));
        transform.GetChild(2).GetComponent<Text>().text = condition;
        reader.Close();
        command.CommandText = "Select condition2 From LevelMsg Where leveIndex = " + level;
        reader = command.ExecuteReader();
        condition = Convert.ToString(reader.GetValue(0));
        transform.GetChild(3).GetComponent<Text>().text = condition;
        reader.Close();
        command.CommandText = "Select condition3 From LevelMsg Where leveIndex = " + level;
        reader = command.ExecuteReader();
        condition = Convert.ToString(reader.GetValue(0));
        transform.GetChild(4).GetComponent<Text>().text = condition;
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //显示星星
    private void Show()
    {
        if (condition1)
        {
            star1.SetActive(true);
            starNum++;
           
        }
        if (condition2)
        {
            star2.SetActive(true);
            starNum++;
        }
        if (condition3)
        {
            star3.SetActive(true);
            starNum++;
            if (condition2)
            {
                star3.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            }
            else
            {
                star3.transform.GetChild(1).GetComponent<Animator>().enabled = true;
            }
        }
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = tile;
        if (!condition1)
        {
            transform.GetChild(7).GetComponent<Button>().enabled = false;
        }
        command.CommandText = "Update LevelMsg Set starnum =" + starNum + " Where leveIndex = " + level;
        command.ExecuteNonQuery();
    }
    //返回菜单
  public  void Menu()
    {
        con.Close();
        SceneManager.LoadScene(0);
        
    }
    //重新玩
  public  void Again()
    {
        con.Close();
        SceneManager.LoadScene(level); //重新载入
       
    }
    //下一关
  public  void Next()
    {
        int nextlevel = level + 1;
        command.CommandText = "Update CurrentLevel Set LevelNow = " + nextlevel;
        command.ExecuteNonQuery(); //执行语句
        con.Close();
        SceneManager.LoadScene(level+1);
     
    }
}
