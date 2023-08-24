using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; // 경로 탐색 라이브러리를 가져옴

public class MovementController2D : MonoBehaviour
{
    [Header("Navigator options")]
    [SerializeField] float gridSize = 0.5f; // 그리드 크기 설정, 큰 맵을 위해 Patience나 gridSize를 늘릴 수 있음
    [SerializeField] float speed = 0.05f; // 움직임 속도 설정, 더 빠른 이동을 위해 값을 증가시킬 수 있음

    Pathfinder<Vector2> pathfinder; // 경로 탐색 메서드와 Patience를 저장하는 Pathfinder 객체
    [Tooltip("Navigator가 통과할 수 없는 레이어들")]
    [SerializeField] LayerMask obstacles;
    [Tooltip("마지막 지점에 도달할 때까지 네비게이터가 그리드 위에서만 움직이도록 비활성화. 경로는 짧아지지만 추가적인 Physics2D.LineCast가 필요함")]
    [SerializeField] bool searchShortcut = false;
    [Tooltip("가장 가까운 그리드 위의 점에서 멈추도록 네비게이터를 설정합니다.")]
    [SerializeField] bool snapToGrid = false;
    Vector2 targetNode; // 2D 공간에서의 목표
    List<Vector2> path;
    List<Vector2> pathLeftToGo = new List<Vector2>();
    [SerializeField] bool drawDebugLines;

    // 첫 번째 프레임 전에 호출되는 함수
    void Start()
    {
        pathfinder = new Pathfinder<Vector2>(GetDistance, GetNeighbourNodes, 1000); // 큰 맵을 위해 Patience나 gridSize를 늘릴 수 있음
    }

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // 새로운 목표를 확인하는 부분
        {
            GetMoveCommand(new Vector2 (0, -8.0f));

            
        }

        if (pathLeftToGo.Count > 0) // 목표에 도달하지 않았을 때
        {
            Vector3 dir = (Vector3)pathLeftToGo[0] - transform.position;
            transform.position += dir.normalized * speed;
            if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude < speed * speed)
            {
                transform.position = pathLeftToGo[0];
                pathLeftToGo.RemoveAt(0);
            }
        }

        if (drawDebugLines)
        {
            for (int i = 0; i < pathLeftToGo.Count - 1; i++) // 시각화를 위해 경로를 화면에 표시
            {
                Debug.DrawLine(pathLeftToGo[i], pathLeftToGo[i + 1]);
            }
        }
    }

    // 목표를 받아와서 움직임 명령을 생성하는 함수
    void GetMoveCommand(Vector2 target)
    {
        Vector2 closestNode = GetClosestNode(transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) // 현재 위치와 목표 위치 주변의 그리드 점으로 경로를 생성
        {
            if (searchShortcut && path.Count > 0)
                pathLeftToGo = ShortenPath(path);
            else
            {
                pathLeftToGo = new List<Vector2>(path);
                if (!snapToGrid) pathLeftToGo.Add(target);
            }
        }
    }

    // 가장 가까운 그리드 점을 찾는 함수
    Vector2 GetClosestNode(Vector2 target)
    {
        return new Vector2(Mathf.Round(target.x / gridSize) * gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    // 거리를 근사화하는 함수
    float GetDistance(Vector2 A, Vector2 B)
    {
        return (A - B).sqrMagnitude; // CPU 시간을 절약하기 위해 제곱 거리를 사용
    }

    // 가능한 연결과 그 거리를 그리드에서 찾는 함수
    Dictionary<Vector2, float> GetNeighbourNodes(Vector2 pos)
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j) * gridSize;
                if (!Physics2D.Linecast(pos, pos + dir, obstacles))
                {
                    neighbours.Add(GetClosestNode(pos + dir), dir.magnitude);
                }
            }
        }
        return neighbours;
    }

    // 경로를 짧게 만드는 함수
    List<Vector2> ShortenPath(List<Vector2> path)
    {
        List<Vector2> newPath = new List<Vector2>();

        for (int i = 0; i < path.Count; i++)
        {
            newPath.Add(path[i]);
            for (int j = path.Count - 1; j > i; j--)
            {
                if (!Physics2D.Linecast(path[i], path[j], obstacles))
                {
                    i = j;
                    break;
                }
            }
            newPath.Add(path[i]);
        }
        newPath.Add(path[path.Count - 1]);
        return newPath;
    }
}