# Unity 2D 픽셀 게임 설정 가이드

## 프로젝트 설정 단계

### 1. 기본 설정
- Unity 2D 프로젝트 생성
- 해상도: 1920 x 1080 (또는 원하는 해상도)
- Rendering: 2D Renderer 또는 Universal RP

### 2.태그 설정
Unity Editor에서 다음 태그를 추가합니다:
- `Player`: 플레이어 게임 오브젝트
- `Enemy`: 적 게임 오브젝트
- `PlayerAttack`: 플레이어 공격 범위

### 3. Layer 설정
- Layer 0: Default
- Layer 1: Player
- Layer 2: Enemy
- Layer 3: Items
- Layer 4: Environment

### 4. 필수 컴포넌트 설정

#### 플레이어 (Player)
```
GameObject: Player
- Transform
- SpriteRenderer (플레이어 스프라이트)
- Rigidbody2D
  - Body Type: Dynamic
  - Constraints: Freeze Rotation Z
  - Gravity Scale: 0
- CircleCollider2D (접촉 감지용)
- BoxCollider2D (지형 충돌용)
- Animator (선택)
- PlayerController 스크립트
- PlayerStats 스크립트
- PlayerAttack 스크립트
- Inventory 스크립트
```

#### 적 (Enemy)
```
GameObject: Enemy (Prefab)
- Transform
- SpriteRenderer (적 스프라이트)
- Rigidbody2D
  - Body Type: Dynamic
  - Constraints: Freeze Rotation Z
  - Gravity Scale: 0
- CircleCollider2D (플레이어 추적용)
- Enemy 스크립트
- Animator (선택)
```

#### 상자 (Treasure Chest)
```
GameObject: TreasureChest
- Transform
- SpriteRenderer (닫힌 상자 스프라이트)
- BoxCollider2D
  - Is Trigger: true
- TreasureChest 스크립트
```

#### 아이템 (Item)
```
GameObject: Item (Prefab)
- Transform
- SpriteRenderer (아이템 스프라이트)
- Rigidbody2D
  - Body Type: Dynamic
  - Gravity Scale: 0
- CircleCollider2D
  - Is Trigger: true
- Item 스크립트
```

### 5. UI 설정

Canvas 생성 후 다음 UI 요소 추가:
```
Canvas
├── HealthText (Text)
│   └── 내용: "HP: 100/100"
├── LevelText (Text)
│   └── 내용: "Level: 1"
├── ExpText (Text)
│   └── 내용: "EXP: 0/100"
├── ScoreText (Text)
│   └── 내용: "Score: 0"
├── WaveText (Text)
│   └── 내용: "Wave: 1"
└── InventoryPanel (Panel) - 초기에 비활성화
    └── (인벤토리 UI 아이템들)
```

### 6. 씬 구조

#### Tutorial Scene
```
- TutorialManager (빈 GameObject)
- Player
- NPC (선택)
- RoomTransition (씬 이동 포인트)
- Canvas (UI)
```

#### GameScene
```
- GameManager (GameManager 스크립트 포함)
- WaveManager (WaveManager 스크립트 포함)
  - SpawnPoint1 (Transform)
  - SpawnPoint2 (Transform)
  - SpawnPoint3 (Transform)
  - SpawnPoint4 (Transform)
- Player (플레이어 설정)
- TreasureChests (비어있는 부모 GameObject)
  - Chest1
  - Chest2
  - Chest3
  - ...
- Enemies (비어있는 부모 GameObject) - 런타임에 생성
- Canvas (UI)
  - HealthText
  - LevelText
  - ExpText
  - ScoreText
  - WaveText
```

### 7. 스폰 포인트 설정 (WaveManager)
GameScene의 WaveManager에서 spawnPoints 배열 설정:
1. 적 4마리 정도가 나올 위치를 Transform으로 지정
2. 플레이어 주변이 아닌 씬 가장자리 지정 권장

### 8. Prefab 생성
프로젝트를 세팅한 후, 다음을 Prefab으로 저장:
- Assets/Prefabs/Enemy.prefab
- Assets/Prefabs/Item.prefab
- Assets/Prefabs/TreasureChest.prefab

### 9. 입력 설정
Project Settings > Input Manager
- Horizontal: A/D 또는 좌우 화살표
- Vertical: W/S 또는 위아래 화살표
- Fire1: 마우스 좌클릭

### 10. 게임 실행
1. GameScene 실행
2. 플레이어가 스폰
3. 3초 후 첫 웨이브 시작
4. 상자에서 아이템 파밍
5. 적을 처치하여 경험치 획득

## 조작법

| 키 | 기능 |
|----|------|
| WASD | 이동 |
| 좌클릭 | 공격 |
| E | 상자 열기 / 방 이동 |
| I | 인벤토리 열기 |

## 난이도 조정

### 쉬움
- monstersPerWave: 3
- moveSpeed (Enemy): 1.5
- attackCooldown (Player): 0.3

### 보통 (기본값)
- monstersPerWave: 5
- moveSpeed (Enemy): 2
- attackCooldown (Player): 0.5

### 어려움
- monstersPerWave: 8
- moveSpeed (Enemy): 3
- attackCooldown (Player): 0.7
