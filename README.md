## 목차

### 1. 프로젝트 설명</br>
### 2. 기술서 & *Trello &깃허브 링크</br>
### 3. 기능 시연


*Trello : 프로젝트 진행상황 및 개발 진척을 메모하는 협업 사이트

## 1. 프로젝트 설명

- Godot 엔진으로 개발된 인디게임 Dome keeper를 모방한 프로젝트입니다.
    
-  Dome keeper는 외계행성에서 돔  구조물을 설치하고,</br>
   자원을 채굴하여 외계 생명체를 막는 디펜스 로그라이크 게임입니다.</br>
   본 프로젝트에서는 몬스터 웨이브, 채광, 펫, 스킬트리 시스템을 모방하였습니다.</br>

 - 몬스터의 행동 알고리즘은 FSM을 사용하여 구현하였고,</br>
    방어타워는 배타적 스킬트리를 채용하여, 하나의 테크만 선택 가능합니다.
    
    광산은 TileMap의 지반에 Gameobject의 광물을 배치하였으며,</br>
    펫은 A* 알고리즘을 사용하여 목적지를까지 이동합니다.
  
    
-  제가 담당한 파트는 조장으로서 일정 조율과 </br>
   프로젝트 조원으로서 몬스터 AI 및 돔과의 상호작용입니다.
    

## 2. 기술서 & Trello &깃허브

기술서 : 

Trello 링크 : https://trello.com/b/QUnailvm/domekeeper

깃허브 : https://github.com/wlsrb0147/DomeKeeperR

## 3. 기능 시연

1. 몬스터 8종 AI</br>
    ![몬스터](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/17153811-c73c-46b2-abab-d101966ff303)

    
    

2. 타워 스킬트리</br>
    ![Honeycam 2024-01-02 03-31-56](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/c6ab3ba6-8eca-4676-b172-c33728b7103f)

   
    

3. A* 알고리즘 길찾기</br>
    ![Honeycam 2023-12-26 14-15-01](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/6db84231-e70f-4504-94af-13d05f44b060)

    
    

4. 타일맵</br>
    ![Honeycam 2024-01-02 03-30-08](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/b84746db-3182-4afa-b5de-ce129ef6e432)</br>
![Untitled](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/53d7ae07-6e06-4431-a00b-2dbe38273e13)

   
    사진의 점들은 광물을 나타냅니다.
