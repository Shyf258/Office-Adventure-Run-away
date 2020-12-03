using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 4f;
    [Header("转向速度")]
    public float turnSpeed = 2f;
    public bool player_move = true;
    public bool getKey = false;
    public GameObject result; //结算界面
    //开火枪口位置  
    private Transform firePoint;
    //获取虚拟轴
    private float hor, ver;
    //计时器
    private float timer;
    //移动方向向量
    private Vector3 dir;
    //获取动画组件
    private Animator ani;
    //两个相机组件，用于切换视角
    private GameObject cam1;
    private GameObject cam3;
    //死亡时候给个特写
    private GameObject camDead;
    [HideInInspector]
    public int Num = 3;
    [HideInInspector]
    public bool dead = false; //玩家死亡
    private float dieTime = 0; //死亡等待时间
    int a = 1;
    int b = 0;
    float time = 0;
    //房顶
    private MeshRenderer mesh;


    private void Awake()
    {
        player_move = true;
        ani = GetComponent<Animator>();
        cam1 = GameObject.FindWithTag("Camera1");
        cam3 = GameObject.FindWithTag("Camera3");    
        GameObject player = GameObject.FindWithTag("Player");
        camDead = GameObject.FindWithTag("CameraDead");
        camDead.SetActive(false);
        cam1.SetActive(false);
        Num = 3;
        mesh= GameObject.Find("Mask").GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        // 获取虚拟轴
        hor = Input.GetAxis(GameConst.HORIZONTAL);
        ver = Input.GetAxis(GameConst.VERICAL);
        Pose();
        Change();
        Die();
        if (dead)
        {
            dieTime+=Time.deltaTime;
            if (dieTime >=1f)
            {
                Instantiate(result, GameObject.Find("BackGround").transform, false);
            }
            
        }

    }


    //切换第一人称操作方式
    void Camear_1()
    {
        if (player_move) 
        {
            if (ver == 0 && hor != 0) //如果只按下转向键
            {
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, 0);
                transform.eulerAngles += hor * Vector3.up * turnSpeed;
            }
            else if (ver > 0 || hor != 0)//前进
            {
                transform.position += ver * transform.forward * Time.deltaTime * moveSpeed;
                transform.eulerAngles += hor * Vector3.up * turnSpeed;
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, GameConst.PLAYER_RUN_SPEED, GameConst.PLAYER_RUN_DAMPTIME, Time.deltaTime);
            }
            else if (ver < 0 || hor != 0)//后退
            {
                transform.position += ver * transform.forward * Time.deltaTime * moveSpeed;
                transform.eulerAngles += hor * Vector3.up * turnSpeed;
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, GameConst.PLAYER_RET_SPEED, GameConst.PLAYER_RUN_DAMPTIME, Time.deltaTime);
            }
            
            else
            {
                //回归站立状态
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, 1.4f);
            }
        }
           
    }
    //切换第三人称操作方式
    void Camear_3()
    {
        if (player_move)
        {
            
            //按下任意一个方向键
            if (hor != 0 || ver != 0)
            {
                //得到移动的方向向量
                dir = new Vector3(hor, 0, ver);
                //将方向向量转化为四元数
                Quaternion targetQua = Quaternion.LookRotation(dir);
                //lerp到四元数
                transform.rotation = Quaternion.Lerp(transform.rotation, targetQua, Time.deltaTime * GameConst.PLAYER_TURNSPEED);
                //移动
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, GameConst.PLAYER_RUN_SPEED, GameConst.PLAYER_RUN_DAMPTIME, Time.deltaTime);
            }
            else
            {
                //回归站立状态
                ani.SetFloat(GameConst.ANIMATOR_PARA_SPEED, 1.4f);
            }
        }
            
    }
    //切换视角
    void Change()
    {
        
        //切换视角的按键
        if (Input.GetKeyDown(KeyCode.Z))
        {
           
            if (Num == 1)
            {
                Num = 3;
                mesh.enabled = false;
            }
            else
            {
                Num = 1;
                mesh.enabled = true;
            }
        }

        if (Num == 1)
        {
            //切换第一人称时间摄像机
            cam1.SetActive(true);
            cam3.SetActive(false);
            //第一人称操作方式
            Camear_1();
        }
        else if(Num == 3)
        {
            //切换第三人称时间摄像机
            cam1.SetActive(false);
            cam3.SetActive(true);
            //第三人称操作方式
            Camear_3();
        }
    }
    //静止时的动作
    void Pose()
    {
        if (hor ==0 && ver ==0)
        {
            time++;
            if (time>= a)
            {
                a = Random.Range(1, 5);
                b = Random.Range(0, 20);
                GetComponent<Animator>().SetInteger("Idle", b);
            }
        }
    }
    //玩家死亡
    void Die()
    {
        if (dead)
        {
            //关闭第一 第三人称相机
            cam1.SetActive(false);
            cam3.SetActive(false);
            camDead.SetActive(true);
            Num = 4;
            mesh.enabled = false;
            //关闭碰撞体
            GetComponent<BoxCollider>().isTrigger = true;
            //播放死亡动画
            ani.SetBool("Die", true);
            //不可以移动
            player_move = false;
            //黑屏
            GameObject.Find("BackGround").GetComponent<RawImage>().enabled = true;
            GameObject.Find("BackGround").GetComponent<LoadScene>().startScene = false;
        }
    }
    
    
}
