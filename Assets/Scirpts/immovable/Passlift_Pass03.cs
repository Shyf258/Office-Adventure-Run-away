using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Passlift_Pass03 : MonoBehaviour
{
    public bool passGame;
    public bool condition1 ;
    public bool condition2 ;
    public bool condition3 ;
    [Header("结算界面预设体")]
    public GameObject result;
    [Header("电门开关")]
    public GameObject CloseLaser;

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
        if (CloseLaser.GetComponent<CloseLaser>().laserOn)
        {
            condition2 = true;
        }
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>().getKey = false;
        
        //if (GetComponent<GameTime>().min < 1)
        //{
        //    condition3 = true;
        //}
        //GameObject.Find("BackGround").GetComponent<LoadScene>().startScene = false;
        //Instantiate(result,GameObject.Find("BackGround").transform, false);
    }
}
