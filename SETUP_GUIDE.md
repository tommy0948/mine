# Unity 2D 픽셀 게임 - 설정 가이드

## 🎮 프로젝트 구조

```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerController.cs (이동)
│   │   ├── PlayerStats.cs (HP, 레벨, EXP)
│   │   ├── PlayerAttack.cs (공격)
│   │   └── Inventory.cs (인벤토리)
│   ├── Enemy/
│   │   ├── Enemy.cs (적 AI)
│   │   └── WaveManager.cs (웨이브 시스템)
│   ├── Interaction/
│   │   ├── RoomTransition.cs (방 이동)
│   │   └── TreasureChest.cs (상자)
│   ├── Items/
│   │   └── Item.cs (아이템)
│   └── Manager/
│       └── GameManager.cs (점수 관리)
├── Scenes/
│   ├── Tutorial.unity
│   └── GameScene.unity
├── Prefabs/
│   ├── Player.prefab
│   ├── Enemy.prefab
│   ├── TreasureChest.prefab
│   └── Item.prefab
└── Sprites/
    ├── player.png
    ├── enemy.png
    ├── chest_closed.png
    ├── chest_open.png
    └── items/
```

## 🔧 초기 설정

### 1. 태그(Tags) 설정
Edit > Project Settings > Tags 에서 다음 태그 추가:
- `Player`
- `Enemy`
- `PlayerAttack`

### 2. 레이어(Layers) 설정
Edit > Project Settings > Layers 에서 다음 레이어 추가:
- `Player` (0-7번 슬롯 중 아무거나 사용)
- `Enemy`
- `Items`

## 👤 플레이어 프리팹 생성

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **2D Object** → **Sprite** → 새 객체 생성
2. 이름: `Player`
3. 위치: (0, 0, 0)

### 컴포넌트 추가
| Component | 설정 |
|-----------|------|
| **Sprite Renderer** | 플레이어 스프라이트 할당 |
| **Rigidbody 2D** | Body Type: Dynamic, Gravity Scale: 0, Constraints: Freeze Rotation Z |
| **Capsule Collider 2D** | Direction: Vertical |
| **Animator** | 플레이어 애니메이션 컨트롤러 할당 |
| **PlayerController** | 스크립트 추가 |
| **PlayerStats** | 스크립트 추가 |
| **PlayerAttack** | 스크립트 추가 |
| **Inventory** | 스크립트 추가 |

### 태그 및 레이어 설정
- Tag: `Player`
- Layer: `Player`

---

## 👹 적(Enemy) 프리팹 생성

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **2D Object** → **Sprite** → 새 객체 생성
2. 이름: `Enemy`
3. Position: (5, 5, 0)

### 컴포넌트 추가
| Component | 설정 |
|-----------|------|
| **Sprite Renderer** | 적 스프라이트 할당 |
| **Rigidbody 2D** | Body Type: Dynamic, Gravity Scale: 0, Constraints: Freeze Rotation Z |
| **Circle Collider 2D** | Radius: 0.5 |
| **Animator** | 적 애니메이션 컨트롤러 할당 |
| **Enemy** | 스크립트 추가 |

### 태그 및 레이어
- Tag: `Enemy`
- Layer: `Enemy`

---

## 📦 상자(TreasureChest) 프리팹 생성

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **2D Object** → **Sprite** → 새 객체 생성
2. 이름: `TreasureChest`

### 컴포넌트 추가
| Component | 설정 |
|-----------|------|
| **Sprite Renderer** | 상자 스프라이트 할당 |
| **Box Collider 2D** | **Is Trigger: ON** |
| **Animator** | 상자 애니메이션 컨트롤러 할당 |
| **TreasureChest** | 스크립트 추가 |

### 인스펙터 설정
- **Item Prefab**: 드롭할 아이템 프리팹 할당
- **Open Chest Sprite**: 열린 상자 스프라이트 할당

---

## 💰 아이템(Item) 프리팹 생성

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **2D Object** → **Sprite** → 새 객체 생성
2. 이름: `Item`

### 컴포넌트 추가
| Component | 설정 |
|-----------|------|
| **Sprite Renderer** | 아이템 스프라이트 할당 |
| **Circle Collider 2D** | **Is Trigger: ON** |
| **Rigidbody 2D** | Body Type: Dynamic, Gravity Scale: 1 |
| **Item** | 스크립트 추가 |

### 인스펙터 설정
- **Item Type**: `Gold` / `Potion` / `Equipment` 중 선택
- **Value**: 아이템 값 설정 (골드: 10, 포션: 20)

---

## 🚪 방 전환(RoomTransition) 설정

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **2D Object** → **Sprite** → 새 객체 생성
2. 이름: `RoomTransition`
3. 위치: (15, 0, 0) (방의 끝쪽)

### 컴포넌트 추가
| Component | 설정 |
|-----------|------|
| **Sprite Renderer** | 문 또는 포탈 스프라이트 |
| **Box Collider 2D** | **Is Trigger: ON** |
| **RoomTransition** | 스크립트 추가 |

### 인스펙터 설정
- **Next Scene Name**: `GameScene` (또는 다음 씬 이름)

---

## 🌊 웨이브 매니저(WaveManager) 설정

### 게임 객체 생성
1. Hierarchy에서 우클릭 → **Create Empty**
2. 이름: `WaveManager`

### 컴포넌트 추가
1. **WaveManager** 스크립트 추가

### 인스펙터 설정

**Monster Prefab**: Enemy 프리팹 할당

**Spawn Points**: 
- 배열 크기: 4~6 (권장)
- 각 지점에 빈 게임 객체를 자식으로 생성하고 위치 설정:
  - Point 0: (3, 5, 0)
  - Point 1: (-3, 5, 0)
  - Point 2: (5, -3, 0)
  - Point 3: (-5, -3, 0)
  - 각 Spawn Point를 Spawn Points 배열에 할당

**Wave Settings**:
- Monsters Per Wave: `5`
- Time Between Spawns: `1.5`
- Time Between Waves: `5`

---

## 🎨 씬 구성

### Tutorial 씬 레이아웃
```
┌─────────────┐
│ NPC (상호작용)│
│             │
│    Player   │
│  (시작 위치)  │
│             │
└──────E──────┘
      (문)
```

### GameScene 씬 레이아웃
```
┌─────────┬─────────┐
│ 상자     │ 상자     │
│         │         │
│  Player │ WaveArea│
│         │         │
│ 상자     │ 상자     │
└─────────┴──────E──┘
    (다음 방)
```

---

## 📊 UI 캔버스 설정

### 새 Canvas 생성
1. Hierarchy에서 우클릭 → **UI** → **Canvas** → 생성

### 필수 UI 요소

**1. Health Text**
- Canvas의 자식으로 Text 추가
- 이름: `HealthText`
- 위치: 좌상단 (20, -20)
- 텍스트: "HP: 100/100"

**2. Level Text**
- Canvas의 자식으로 Text 추가
- 이름: `LevelText`
- 위치: 좌상단 (20, -50)
- 텍스트: "Level: 1"

**3. Exp Text**
- Canvas의 자식으로 Text 추가
- 이름: `ExpText`
- 위치: 좌상단 (20, -80)
- 텍스트: "EXP: 0/100"

**4. Wave Text**
- Canvas의 자식으로 Text 추가
- 이름: `WaveText`
- 위치: 상단 중앙 (0, -20)
- 텍스트: "Wave: 1"

**5. Score Text**
- Canvas의 자식으로 Text 추가
- 이름: `ScoreText`
- 위치: 우상단 (-20, -20)
- 텍스트: "Score: 0"

---

## ✨ 애니메이션 설정

### 플레이어 애니메이션
1. 플레이어 스프라이트 4개 필요:
   - `player_idle.png`
   - `player_up.png`
   - `player_down.png`
   - `player_left.png`

2. 애니메이션 클립 생성:
   - `PlayerIdle`
   - `PlayerWalk`

3. Animator 파라미터:
   - `moveX` (Float)
   - `moveY` (Float)
   - `speed` (Float)
   - `Attack` (Trigger)

### 적 애니메이션
1. 적 스프라이트 2개 필요:
   - `enemy_idle.png`
   - `enemy_die.png`

2. Animator 파라미터:
   - `moveX` (Float)
   - `moveY` (Float)
   - `Die` (Trigger)

### 상자 애니메이션
1. 상자 스프라이트 2개:
   - `chest_closed.png`
   - `chest_open.png`

2. Animator 파라미터:
   - `Open` (Trigger)

---

## 🎮 테스트 플레이

### 튜토리얼 씬 (Tutorial)
1. Play 버튼 클릭
2. WASD로 이동 테스트
3. E키로 상자 열기
4. E키로 다음 방 이동

### 게임 씬 (GameScene)
1. Play 버튼 클릭
2. 상자 파밍 (E키)
3. 마우스 좌클릭으로 적 공격
4. 웨이브별 몬스터 처치
5. 레벨업 확인

---

## 💡 팁

- **성능 최적화**: 몬스터가 많을 때 Object Pool 사용 권장
- **난이도 조정**: WaveManager의 `monstersPerWave` 값으로 조정
- **사운드**: AudioSource 추가하여 효과음 및 배경음 추가 가능
- **파티클**: 적 사망 시 파티클 이펙트 추가 가능
- **카메라**: Main Camera를 플레이어 위치 추적하도록 설정

---

## 📝 추가 개선 사항

- [ ] 보스 몬스터 추가
- [ ] 스킬 시스템
- [ ] 상점 시스템
- [ ] 세이브/로드
- [ ] 리더보드
- [ ] 사운드 및 음악

