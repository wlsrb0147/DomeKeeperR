using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class M_Base : MonoBehaviour
{
    public M_StateMachine stateMachine { get; private set; }
    public Animator ani;
    public Rigidbody2D rb;

    public Transform domeCenter;
    public float hp;
    
    public int faceX = 1;
    public bool facingRight = true;


    protected virtual void Awake()
    {
        stateMachine = new M_StateMachine();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        domeCenter = GameObject.Find("Dome_Center").GetComponent<Transform>();
    }
    
    protected virtual void Start()
    {
  
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();

        if (transform.position.x > domeCenter.position.x && facingRight )
        {
            facingRight = !facingRight;
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if(transform.position.x < domeCenter.position.x && !facingRight)
        {
            facingRight = !facingRight;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (facingRight) faceX = 1;
        else faceX = -1;
    }
}
