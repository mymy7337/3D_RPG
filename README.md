# 3D_RPG

> Unity 기반 3D 액션 RPG 프로토타입. 던전 탐험, 전투, 아이템/인벤토리, 마을/던전 씬 전환 등을 포함합니다.

---

## 📌 목차
- [개요](#-개요)
- [핵심 기능](#-핵심-기능)
- [기술 스택](#-기술-스택)
- [프로젝트 구조](#-프로젝트-구조)
- [주요 시스템](#-주요-시스템)
- [트러블슈팅](#-트러블슈팅)

---

## 📖 개요
- 경량 3D RPG 샘플/프로토타입 프로젝트입니다.
- **목표**: 전투 루프, 아이템 파이프라인(ScriptableObject → 런타임 인스턴스), 마을/던전/ 등 핵심 루프를 빠르게 검증하고 확장 가능한 구조 확보.

---

## ✨ 핵심 기능
- [x] 플레이어 이동(`NavMeshAgent`)
- [x] 3D 전투(애니메이션 연동, 기본 AI 추적)
- [x] 인벤토리/아이템(데이터 SO, 런타임 인스턴스 복제)
- [x] 장비/강화(장착 시 스텟 반영)
- [ ] 저장/로드(JSON, `Application.persistentDataPath`)

---

## 🛠 기술 스택
- **Engine**: Unity 
- **Language**: C#
- **AI/이동**: NavMeshAgent
- **Data**: ScriptableObject, JSON 직렬화

---

## 🗂 프로젝트 구조
```
Assets/
├─ 01. Scenes/ # Main, Stage 등
├─ 02. Scripts/
│ ├─ Enemy/ # 적 스텟 및 이동
│ ├─ Equip/ # 장비 및 강화
│ ├─ Inventory/ # 인벤토리 및 아이템 장착
│ ├─ Player/ # 플레이어 스텟 및 이동
│ ├─ Shop/ # 상점
│ └─ UI/ # 각종 UI
├─ 03. Animations/ # 애니메이션
├─ 04. ScriptableObjects/ # 데이터
├─ 05. Prefabs/
└─ 999. Assets/
```
---

## 🎮 컨트롤
- **이동**: `NavMeshAgent`기반 자동 이동
- **공격/조준**: `Physics.OverlapSphereNonAlloc`를 이용한 적 자동 인식 및 공격
---

## 🧩 주요 시스템

### 아이템/인벤토리
- `ItemDataSO`(데이터) → 런타임 `ItemInstance`로 복제하여 사용  
- 강화/내구도 등 *런타임에서 바뀌는 값은* SO를 직접 수정하지 않고 **인스턴스에만 보관**  

### 전투/AI
- `NavMeshAgent` 기반 추적
- `StateMachine` 기반 공격/이동 상태 전환

### 저장/로드
- JSON 직렬화(캐릭터 스텟)  
- 경로: `Application.persistentDataPath`

## 🧯 트러블슈팅
- **Animator 파라미터 불일치**: 파라미터 명 대소문자 확인
- **Awake/Start 시점 이슈**: 동적 생성 자식 참조는 `Start` 이후 또는 `OnEnable`에서
- **Item 슬롯 널 체크**: 슬롯 객체와 `itemData` 둘 모두 체크 (초기화 시 더미 인스턴스가 들어가 있을 수 있음)

---
