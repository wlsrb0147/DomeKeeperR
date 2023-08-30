using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towe : MonoBehaviour
{
    [SerializeField] private Transform domeCenter;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform laserSpawnPoint;

    private bool isRotating = false;

    private void Update()
    {
        HandleRotation();
        HandleAttack();
    }

    private void HandleRotation()
    {
        // 돔 회전 처리
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            domeCenter.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            domeCenter.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleAttack()
    {
        // 회전 중에 공격 가능한지 체크
        if (isRotating)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireLaser();
            }
        }
    }

    private void FireLaser()
    {
        // 레이저 발사
        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
        Destroy(laser, 2f); // 일정 시간 후에 레이저 파괴

        // 회전 중에는 레이저를 발사할 수 없도록 처리
        isRotating = false;
        Invoke(nameof(EnableAttack), 1f); // 1초 후에 다시 공격 가능하게 설정
    }

    private void EnableAttack()
    {
        isRotating = true;
    }
}