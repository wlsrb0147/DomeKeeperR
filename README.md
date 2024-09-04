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
## 3. 기능 시연

몬스터 8종 AI</br>
    ![몬스터](https://github.com/wlsrb0147/DomeKeeperR/assets/50743287/17153811-c73c-46b2-abab-d101966ff303)

주요 몬스터 

Flyer</br>
![Honeycam 2024-09-04 16-42-37](https://github.com/user-attachments/assets/dea94390-2161-456b-92a2-b462226bce33)

Diver</br>
![Honeycam 2024-09-04 16-42-22](https://github.com/user-attachments/assets/a4424abc-8514-47e0-b6ab-5b1aa08272d5)
