using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Passlift_Pass04 : MonoBehaviour
{
    public bool passGame;
    public bool condition1 ;
    public bool condition2 ;
    public bool condition3 ;
    [Header("结算界面预设体")]
    public GameObject result;
    [Header("机关")]
    public GameObject Close;

    // Start is called before the first frame update
    void Start()
    {
      //通关获得星星条件
      condition1 = false;
      condition2 = false;
      condition3 = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        //过关
        //失去钥匙 
        condition1 = true;
        if (GetComponent<GameTime>().min<2)
        {
            condition2 = true;
        }
        if (Close.GetComponent<LaserCLose102>().NoTable)
        {
            condition3 = true;
        }  
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>().getKey = false;
        GameObject.Find("BackGround").GetComponent<LoadScene>().startScene = false;
        Instantiate(result,GameObject.Find("BackGround").transform, false);
    }
}
