using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class Nav : MonoBehaviour
{
    [HideInInspector]
    public bool move = false;
    public Flowchart fungus;
    private NavMeshAgent nav;
    private Transform pass;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        pass = GameObject.FindWithTag("Pass").transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = fungus.GetBooleanVariable("move");
        
        if (move)
        {
            nav.SetDestination(pass.transform.position);
            Animator an = GetComponent<Animator>();
            an.SetFloat("Speed", 3f);

        }
    }
}