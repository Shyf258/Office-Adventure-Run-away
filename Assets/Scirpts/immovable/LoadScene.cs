using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private RawImage raw;
    //渐变色速度
    private float fadeSpeed=1;
    //进入或退出游戏
    [HideInInspector]
    public bool startScene;
    
    private void Awake()
    {
       
        raw = this.GetComponent<RawImage>();
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, Screen.height);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        startScene = true;
    }
    //变透明
    private void Clear()
    {
        raw.color = Color.Lerp(raw.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //变黑
    private void Black()
    {
        raw.enabled = true;
        raw.color = Color.Lerp(raw.color, Color.black, fadeSpeed *4* Time.deltaTime);
    }
    //进入场景
    private void StartScene()
    {
        Clear();
        if (raw.color.a <=0.05)
        {
            raw.color = Color.clear;
            raw.enabled = false;
        }
        
    }
    //退出场景
    private void EndScene()
    {
        Black();
        if (raw.color.a >=0.95)
        {
            raw.color = Color.black;
        }
       
    }
    // Update is called once per frame
    private void LoadGame()
    {
        if (startScene)
        {
            StartScene();
        }
        else
        {
            EndScene();
        }
    }
    private void Update()
    {
        LoadGame();
    }
}
