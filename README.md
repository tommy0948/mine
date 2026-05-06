# Unity 2D Top-View Pixel Game

유니티로 만든 2D 탑뷰 픽셀 게임입니다.

## 게임 구조

### 1. 튜토리얼 방 (Tutorial Scene)
- 플레이어 이동 연습
- NPC 상호작용
- 인벤토리 시스템 기초
- 다음 방으로 이동하기

### 2. 게임 플레이 방 (Game Scene)
- 상자에서 아이템 파밍
- 웨이브 시스템으로 몬스터 소환
- 몬스터 처치
- 레벨/경험치 시스템

## 파일 구조

```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   ├── PlayerStats.cs
│   │   └── Inventory.cs
│   ├── Enemy/
│   │   ├── Enemy.cs
│   │   ├── WaveManager.cs
│   │   └── EnemySpawner.cs
│   ├── Items/
│   │   ├── Item.cs
│   │   ├── Box.cs
│   │   └── ItemSpawner.cs
│   ├── UI/
│   │   ├── InventoryUI.cs
│   │   ├── WaveUI.cs
│   │   └── StatsUI.cs
│   └── Manager/
│       ├── GameManager.cs
│       └── SceneManager.cs
└── Scenes/
    ├── Tutorial.unity
    └── GameScene.unity
```

## 게임 플레이

### 조작
- **WASD**: 이동
- **E**: 상호작용 / 상자 열기
- **I**: 인벤토리 열기

### 게임 진행
1. 튜토리얼에서 기본 조작 학습
2. 게임 방에서 상자를 열어 아이템 획득
3. 웨이브별 몬스터 처치
4. 경험치 획득 및 레벨업

