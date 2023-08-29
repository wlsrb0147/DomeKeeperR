using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_DiverWarner : M_Moving
{
    public O_DiverWarnerActive active { get; private set; }
    Vector2 dir;

    protected override void Awake()
    {
        base.Awake();
        active = new O_DiverWarnerActive(this, stateMachine, "Active");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(active);

        dir = Getdir();
        float angle = Mathf.Atan2(dir.x, dir.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,180-angle);
            
        dir = dir.normalized * moveSpeed.x;
        SetVelocity(dir);

        Debug.Log(transform.position + "," + transform.rotation);


    }

    protected override void Update()
    {
        base.Update();
    }
}
