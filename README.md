## 팀명
QuestMakers
## 게임명
훈련소 탈출하기
## 게임 배경
훈련도중 도저히 참지 못하고 이탈한 훈련병! 하지만 탈출하는 것 또한 만만치 않은데… 과연 훈련병은 무사히 탈출해 집으로 돌아갈 수 있을것인가!
***
## 👥 프로젝트 참여 인원
정주찬, 박민혁, 고영현, 김나운, 최장범
## ⚙️ 개발 환경
Unity 2022.3.2f1
C#
## 💻 에셋
메인: https://assetstore.unity.com/packages/3d/environments/urban/polygon-battle-royale-low-poly-3d-art-by-synty-128513

UI: https://assetstore.unity.com/packages/tools/gui/3d-modern-menu-ui-116144

BGM /SFX: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116
## ⏰ 개발일정
2023.10.13 ~ 2023.10.20
## 🖼️ 와이어 프레임
https://www.figma.com/file/cCArtcggV5VmdO2euyLhEe/B10?type=design&node-id=0-1&mode=design&t=ley9X7k3RFj32FAh-0

<img width="560" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/c82cd71f-c689-4fd3-98b1-e9dc45d3c072">
<img width="323" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/a826f229-3438-487b-acde-63ed58c5f1cb">
<img width="418" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/ba3e90b4-0310-43e3-beda-cb489f9abc61">
<img width="232" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/739114d6-ac90-4c0c-b30d-cc30492cbace">
<img width="277" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/892ff487-b0d3-4033-999a-694c805812c6">
<img width="445" alt="image" src="https://github.com/JeongJuChan/QuestMakers/assets/141592625/08f5ccdb-81fb-4d72-bbd0-30410d8d97be">

## 영상 링크
https://youtu.be/biv73FHSKDY?si=ST-NWeF5dGxSYmvf

## 💡 기능
### 게임시작 화면
- 게임 배경 이미지
- 게임 타이틀
- 시작 버튼
### 로딩 화면
- 로딩 바
- 로딩 텍스트
### 메인메뉴 화면
- 두가지의 게임모드를 선택 할수 있는 씬
  - 아케이드 모드
  - 스토리 모드
### 아케이드메뉴 화면
- 여러 종류의 미니게임들을 선택할 수 있는 씬
- 메인메뉴로 돌아가기 버튼
### 게임화면
- 빙글빙글 탱크 게임
- 폭탄 찾기 게임
- 보급품 모으기 게임
- 사격 연습 게임
- 교관을 피해라 게임
### 엔딩화면
- 스토리 모드의 엔딩
## 💚 역할 분담
- 팀과제
    - 정주찬
        - 사운드 매니저
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/Managers/SoundManager.cs#L1
        - 씬 매니저
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/JangbeomScripts/SceneLoad/SceneLoadManager.cs#L1
        - 엔딩 씬
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/Ending/EndingScene.cs#L1
        ![image](https://github.com/JeongJuChan/QuestMakers/assets/95285906/11881b4d-56f5-4c3d-afa3-10b3cd59de08)
        - 돌 피하기
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/GoingUp.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/GoingUpScore.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/Obstacles/Obstacle.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/Obstacles/ObstacleCollision.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/Obstacles/ObstacleShooter.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/Obstacles/ObstacleSpawner.cs#L1
        https://github.com/JeongJuChan/QuestMakers/blob/e6c2c48ee8ed3098f127ef688c7312cd7c9f245a/Assets/Scripts/GoingUp/Obstacles/SpawnTimeCalculator.cs#L1
        ![image](https://github.com/JeongJuChan/QuestMakers/assets/95285906/09ed65cc-ade3-4b9e-98ba-2dd3eb06d9e1)
    - 최장범
        - ~~슈팅게임 몹잡기~~
        - 팩맨 3D버전
        - 모드 시스템
            - [x]  자유모드 (아케이드 씬으로 이동)
            - [ ]  스토리모드 (랜덤한 씬으로 이동)
            - [x]  메인메뉴 씬
            - [x]  게임시작 씬
        - 추가구현
            - [x]  로딩화면        
    - 김나운
        
        보상 시스템(재화)
        
        -스킨구매
        
        시계 생존        
    - 박민혁
        
        빗물받이르탄이
        
        조작입력
        
        사격 스테이지     
    - 고영현
        - 무한계단 3D버전
        - 데이터 저장
        - UI 매니저
          
## 🐛버그 리포트
10/19

 - [x]  적 오브젝트가 장애물들을 통과하는 버그
 - [x]  스페셜 코인을 연속으로 먹으면 효과가 중첩이 안되는 버그
 - [x]  스페셜 코인 먹었을 시에 효과음 안나오는 버그

10/20

- [x]  빗물 피하기 캐릭터 2개되는버그
- [x]  팩맨3d 아케이드 게임나가기 안되는 버그
- [x]  UI 창 안뜨는 오류
- [x]  bestscore 점수 저장 안되는 오류
- [x]  NullreferenceException오류

## 어려웠던 부분 / 아쉬웠던 부분
- 주찬
    - 어려웠던 부분
        - 점수 계산과 데이터를 관리하는데 연동하는 부분이 조금 어려웠던 것 같다.
    - 아쉬웠던 부분
        - 시간에 쫓겨서 확장성 있는 코드를 짜지 못한 게 아쉽다.
- 장범
    - 어려웠던 부분
        - 최고점수를 표시하고 저장하는 방식이 익숙하지 않아서 어려웠습니다. UI부분도 계속해서 일어나던 nullreferenceexeption오류를 해결하는 것이 어려웠는데 팀원분들이 잘 도와주셔서 해결할 수 있었습니다.
    - 아쉬웠던 부분
        - 점수나 UI부분에서는 정말 이해하기가 너무 어려웠어서 팀원분들의 작업이나 어려움을 도와드리지 못한것이 아쉬웠습니다.
- 나운
    - 어려웠던 부분
      - 확장성 있는 코드를 짜는 것과 팀원들의 코드를 정확하게 읽고 활용하는 부분이 어려웠음.
      - 점수 계산과 데이터 관리 부분에서 어려웠음.
    - 아쉬웠던 부분
      - 공통 기능을 완벽하게 공유하여 사용하지 못하였음.
- 민혁
    - 어려웠던 부분
        - 전체적으로 다른 분들 코드를 이해하는데 어려웠다 코드 보는 법을 많이 연습해봐야 할 것 같다
        - 캐릭터 애니메이션 중  공중에 있을때 상승 상태인지 하강 상태인지가 어려웠다
    - 아쉬웠던 부분
        - 만든 미니 게임이 재미가 부족 하다
- 영현
    - 어려웠던 부분
        - 계단을 올라가는 애니메이션 처리가 어려웠던 것 같습니다. 툭툭 끊기는 부분을 좀 더 보완할 수 있는 방법을 찾을 수 있었다면 좋았을 것 같습니다.
    - 아쉬웠던 부분
        - UIManager을 제가 담당해서 했는데 너무 복잡하게 짠 거 같아서 팀원들이 고생한 것 같습니다. 좀 더 쉽게 할 수 있는 방법을 찾아야 될 것 같습니다.
        - 몸 상태가 너무 안 좋아서 프로젝트에 기여를 잘 못한 것 같아서 아쉽습니다.







