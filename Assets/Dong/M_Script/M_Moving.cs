using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Moving : M_Base
{
    public float movingSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetVelocity(float InputX, float InputY)
    {
        rb.velocity = new Vector2(InputX*faceX, InputY);
    }
}
