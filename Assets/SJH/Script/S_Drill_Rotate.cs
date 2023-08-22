using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class S_Drill_Rotate : MonoBehaviour
{
    Vector3 MousePosition;
    public float rotationSpeed = 10;

    void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward); //z축을 기준으로 angle값 만큼 회전
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotationSpeed);
        transform.rotation = rotation;
    }

  
}

