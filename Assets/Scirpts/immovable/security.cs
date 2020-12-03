using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class security : MonoBehaviour
{
    //保安巡逻脚本
    private Transform player;
    private RaycastHit hit;
    //玩家的动画状态机
    private Animator playerani;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(GameConst.PLAYER).GetComponent<Transform>();
        playerani = player.gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        EnemySighting();
        
    }
    private void EnemySighting()
    {
        //当前机器人指向玩家的方向向量
        Vector3 dir = player.position - transform.position;
        //如果超出视野最大距离，直接返回
        if (dir.magnitude > GameConst.ENEMY_SIGHT_DISTANCE)
            return;
        //计算当前机器人前方方向向量与指向玩家的方向向量的夹角
        float angle = Vector3.Angle(transform.forward, dir);
        //如果超出视野最大夹角范围，直接返回
        if (angle > GameConst.ENEMY_SIGHT_RANGE / 2)
            return;
        //射线并未检测到任何碰撞体，直接返回
        if (!Physics.Raycast(transform.position + Vector3.up * GameConst.ENEMY_EYES_OFFSET, dir, out hit))
            return;
        //射线满足的是玩家
        if (hit.collider.CompareTag(GameConst.PLAYER))
        {
            //游戏结束
            GetComponent<iTween>().enabled = false;
            GetComponent<Animator>().SetBool("Active", false);
            player.GetComponent<PlayerMovement>().dead = true;
        }
    }
}
