using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flikerLight : MonoBehaviour
{
    [Header("闪烁间隔")]
   public int time =7;
    int a;
    Light light;
    private GameObject cam1;
    private GameObject cam3;
    private void Awake()
    {
        cam3 = GameObject.FindWithTag("Camera3");
        cam1 = GameObject.FindWithTag("Camera1");
    }
    // Start is called before the first frame update
    void Start()
    {
       light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        a = Random.Range(1, 40);
        if (a < time)
        {
            light.intensity = 0;
        }
        if (a <= 40 && a >= time)
        {
            light.intensity = 4;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==GameConst.PLAYER)
        {
            //切换第三人称
            GameObject.FindWithTag(GameConst.PLAYER).GetComponent<PlayerMovement>().Num = 1;
        }
        
    }
    
}
