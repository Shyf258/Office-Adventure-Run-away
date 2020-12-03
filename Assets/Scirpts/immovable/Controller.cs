using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Controller : MonoBehaviour
{
    public Flowchart fungus;
    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().player_move = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().player_move = fungus.GetBooleanVariable("player_move");
    }
}
