using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class goTheRounds : MonoBehaviour
{
   
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        //iTween.MoveTo(gameObject, iTween.Hash
        //    ("path", tarGetPoint, "orienttopath", true, "looktime", 1.5f, "axis", "y", "time", 10,
        //    "speed", 5, "delay", 5, "easetype", "easeOutCirc",
        //    "looptype", "loop"));
        
        //itween要用到的参数 args
        Hashtable args = new Hashtable();

        //设置itween移动的类型
        args.Add("easeType", iTween.EaseType.linear);

        //设置移动的速度
        args.Add("speed", 5f);
        ////设置移动的时间
        //args.Add("time", 5f);

        //延迟执行
        args.Add("delay", 0);

        //是否让游戏对象始终面朝路径行进的方向，拐弯的地方会自动旋转。
        args.Add("orienttopath", true);

        //移动的过程中面朝一个点，当“orienttopath”为true时该参数失效
        args.Add("looktarget", Vector3.zero);

        //游戏对象看向“looktarget”的秒数。
        args.Add("looktime", 0.2f);

        //游戏对象移动的路径通过iTweenPath编辑获取路径(参数为路径名字)
        args.Add("path", iTweenPath.GetPath("Rounds"));

        //按照原路返回
        //获取逆向路径
        //args.Add("path", iTweenPath.GetPathReversed("New Path 1"));

        //是否移动到路径的起始位置（false：游戏对象立即处于路径的起始点，true：游戏对象将从原是位置移动到路径的起始点）
        args.Add("movetopath", false);

        //当包含“path”参数且“orienttopath”为true时，该值用于计算“looktarget”的值，表示游戏物体看着前方点的位置，（百分比，默认0.05）
        args.Add("lookahead", 0.01);

        //是否使用局部坐标(默认为false)
        args.Add("islocal", false);

        args.Add("loopType", iTween.LoopType.loop);

        iTween.MoveTo(gameObject, args);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
