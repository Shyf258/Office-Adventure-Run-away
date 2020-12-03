using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConst
{
    #region Game Tags 游戏标签

    public const string MAIN_LIGHT = "MainLight";
    public const string ALARM_LIGHT = "AlarmLight";
    public const string SIREN = "Siren";
    public const string PLAYER = "Player";
    
    #endregion

    #region Game Parameters 游戏参数

    //警报闪烁和声音渐变速度参数
    public const float ALARM_TURNSPEED = 6f;
    //玩家转身速度
    public const float PLAYER_TURNSPEED = 10f;
    //玩家跑起来的速度
    public const float PLAYER_RUN_SPEED = 3.5f;
    //玩家倒退的速度
    public const float PLAYER_RET_SPEED = -3.5f;
    //摄像机跟随的速度
    public const float CAMERA_FOLLW_SPEED = 3f;
    //摄像机旋转的速度
    public const float CAMERA_TURN_SPEED = 2f;
    //玩家从走到跑的过渡时间
    public const float PLAYER_RUN_DAMPTIME = 1f;
    //摄像机俯视玩家的偏移量
    public const float CAMERA_UNDERWATCH_OFFSET = 0f;
    //摄像机观察档位（可选视角位置的个数）
    public const int CAMERA_WATCH_GEAR = 5;
    //玩家身体偏移量
    public const float PLAYER_WATCHBODY_OFFSET = 1f;
    //激光的开关单元的触发距离
    public const float SWITCH_UNIT_TRIGGERDISTANCE = 2f;
    //电梯上升速度
    public const float LIFT_RAISE_SPEED = 0.8f;
    //敌人视野范围最大夹角
    public const float ENEMY_SIGHT_RANGE = 80;
    //敌人视野范围最远距离
    public const float ENEMY_SIGHT_DISTANCE = 8;
    //敌人眼镜与坐标的偏移量
    public const float ENEMY_EYES_OFFSET = 1.7f;
    //敌人听得最大距离
    public const float ENEMY_HEAR_DISTANCE = 10;
    #endregion

    #region Game Virtual Axis/Button Name 虚拟轴/按键的名称

    public const string HORIZONTAL = "Horizontal";
    public const string VERICAL = "Vertical";
    public const string V_BTN_SNEAK = "Sneak";
    public const string V_BTN_SHOUT = "Shout";
    public const string V_BTN_SWITCH = "Swith";

    #endregion


    #region Game Animator Parameters/States 游戏动画参数/状态

    public static int ANIMATOR_PARA_SPEED;
    public static int ANIMATOR_PARA_SNEAK;
    public static int ANIMATOR_PARA_SHOUT;
    public static int ANIMATOR_PARA_DOOROPEN;
    public static int ANIMATOR_STATE_LOCOMOTION;

    #endregion

    #region Assets Path 资源路径

    public const string SHOUTCLIP_PATH = "Audio/player_attractAttention";
    public const string DOOROPENCLIP_PATH = "Audio/door_open";
    public const string DOORACCSEEDENIED_PATH = "Audio/door_accessDenied";
    public const string SWITCHUNITCLIP_PATH = "Audio/switch_deactivation";
    public const string KEYCARDCLIP_PATH = "Audio/keycard_pickUp";
    public const string LIFTRAISE_PATH = "Audio/lift_raise";


    #endregion

    #region Static Consturctor 静态构造函数

    static GameConst()
    {
        //给动画参数Hash赋值
        ANIMATOR_PARA_SPEED = Animator.StringToHash("Speed");
        ANIMATOR_PARA_SNEAK = Animator.StringToHash("Sneak");
        ANIMATOR_PARA_SHOUT = Animator.StringToHash("Shout");
        ANIMATOR_PARA_DOOROPEN = Animator.StringToHash("DoorOpen");
        ANIMATOR_STATE_LOCOMOTION = Animator.StringToHash("Locomotion");

    }

    #endregion


}