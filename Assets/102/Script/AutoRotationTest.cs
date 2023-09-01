using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotationTest : MonoBehaviour
{
    public float angularSpeed = 30.0f; // 좌우 자동 회전 속도 (도/초)
    public float leftLockAngle = -45.0f; // 좌측 회전 제한 각도
    public float rightLockAngle = 45.0f; // 우측 회전 제한 각도

    void Update()
    {
        AutoRotate();
    }

    void AutoRotate()
    {
        float rotationAmount = angularSpeed * Time.deltaTime;

        if (transform.rotation.eulerAngles.z < leftLockAngle)
        {
            rotationAmount = Mathf.Abs(rotationAmount);
        }
        else if (transform.rotation.eulerAngles.z > rightLockAngle)
        {
            rotationAmount = -Mathf.Abs(rotationAmount);
        }

        transform.Rotate(0, 0, rotationAmount);
    }
}
