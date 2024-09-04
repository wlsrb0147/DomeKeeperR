## 목차

### 1. 프로젝트 설명</br>
### 2. 기술서 & *Trello & 시연영상</br>
### 3. 기능 시연


*Trello : 프로젝트 진행상황 및 개발 진척을 메모하는 협업 사이트

## 1. 프로젝트 설명

- Godot 엔진으로 개발된 인디게임 Dome keeper를 모방한 프로젝트입니다.
    
-  Dome keeper는 외계행성에서 돔  구조물을 설치하고,</br>
   자원을 채굴하여 외계 생명체를 막는 디펜스 로그라이크 게임입니다.</br>
   본 프로젝트에서는 몬스터 웨이브, 채광, 펫, 스킬트리 시스템을 모방하였습니다.</br>

 - 몬스터의 행동은 FSM에 의해 제어되며, </br> 각각의 행동에서 필요한 계산이 처리됩니다.</br>
 
    방어타워는 배타적 스킬트리를 채용하여, 하나의 테크만 선택 가능합니다.
    
    광산은 TileMap의 지반에 Gameobject의 광물을 배치하였으며,</br>
    펫은 A* 알고리즘을 사용하여 목적지를까지 이동합니다.
  
    
-  제가 담당한 파트는 조장으로서 일정 조율과 </br>
   프로젝트 조원으로서 몬스터 AI 및 돔과의 상호작용입니다.
    

## 2. 기술서 & Trello & 시연영상


설명 pdf파일 : https://drive.google.com/file/d/114VbrcBGwP7Jm56TUnkhB48TqvMqy7qA/view?usp=sharing
</br>(목차 포함 9p)
 
Trello 링크 : https://trello.com/b/QUnailvm/domekeeper </br></br>
시연영상 : https://youtu.be/c1NKMUqizPU</br>
## 3. 기능 시연 및 스크립트와 로직
모든 몬스터 스크립트는
Assets/Dong/M_Script에 저장되어있습니다.


### 몬스터 8종 AI</br>
    ![몬스터](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/17153811-c73c-46b2-abab-d101966ff303)

### 몬스터 주요 구성</br>
![몬스터 drawio](https://github.com/user-attachments/assets/e454e29c-2d51-4fe6-ad7c-fa0a8934cb1f)</br></br>


MonsterBase : Assets/Dong/M_Script/M_Base</br>
몬스터 프리팹 : Assets/Dong/MonsterPrefab</br>
몬스터 State : Assets/Dong/M_Script/M_몬스터명</br>
O_스크립트는 투사체를 나타냅니다.</br>
M_Moving과 M_holding는 움직임 여부로 구분하였습니다.</br>


### 주요 몬스터</br>

### Flyer</br>
![Honeycam 2024-09-04 16-42-37](https://github.com/user-attachments/assets/dea94390-2161-456b-92a2-b462226bce33)

### 핵심 기술 : 회전행렬</br>
![image](https://github.com/user-attachments/assets/4d402e6e-c1ba-470c-b558-985185aa2d8a)</br>
현재좌표와 목표지점을 지름으로 하는 원을 그리고, 원의 중심을 기준으로 90' 회전시킨 좌표를 경유지로 베지에 곡선을 따라 이동합니다.</br>
경유지에 무작위성을 부여하기 위하여 중심을 좌표로 1/3r, 1/2r, r만큼 떨어진 좌표를 랜덤으로 설정합니다.</br>
이동속도를 일정하게 유지하기 위하여 시작점 - 경유지 - 목적지까지의 거리를 측정 후, 속도/거리값을 Lerp의 T값으로 할당하였습니다</br>

스크립트 </br>
좌표 설정 : Assets/Dong/M_Script/M_Flyer/M_FlyerHide.cs</br>
Lerp 이동 : Assets/Dong/M_Script/M_Flyer/M_FlyerMove.cs</br>

### Diver</br>
![Honeycam 2024-09-04 16-42-22](https://github.com/user-attachments/assets/a4424abc-8514-47e0-b6ab-5b1aa08272d5)</br>
Diver는 플레이어 시야밖의 무작위 위치에서 생성되며, 공격 전 Warner를 통해 공격 신호를 보냅니다.</br>
### 핵심 기술 : 삼각형 닮음</br>
![image](https://github.com/user-attachments/assets/672be72a-a9bb-4718-8e5d-0cdad896a28a)</br>
Warner는 플레이어 시야의 끝에서 생성되며</br>
기지 중앙과 몬스터를 잇는 선분과 플레이어 시야 모서리의 교차점에서 스폰됩니다.</br>
![image](https://github.com/user-attachments/assets/b58eed69-5ec4-4e9a-9790-9a159452af24)</br>

따라서 x좌표 max와 y좌표 max값을 구한 후, 삼각형의 닮음비를 통하여 좌표값을 계산하였습니다.</br>

Warner 스폰 스크립트 : Assets/Dong/M_Script/M_Diver/M_Diver.cs , OnBecameInvisible()</br>
