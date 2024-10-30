# Sparta_Unity_Skilled_Assignment
 week 6, skilled assignment sparta dungeon

### InputAction
기능 1 : 기본 이동[ W, A, S, D ] (상 하 좌 우)
기능 2 : 점프 [SpaceBar]
기능 3 : 시야전환(카메라각 변화) [마우스 이동]
기능 4 : 아이템 사용 [R]
기능 5 : 상호작용(미구현) [E]
![image](https://github.com/user-attachments/assets/7d0dd81d-2e0d-483c-9d26-cd41ab19991a)

### UI
![image](https://github.com/user-attachments/assets/3ebd5f44-a9ea-413e-a236-6739f11bca3c)
기능 1 : hp 바 표시, 프레임마다 5씩 감소, 감소 시 게이지 바 업데이트
기능 2 : 중앙의 보라색 점 방향으로 ray를 사용하여 오브젝트와 상호작용
기능 3 : Ray를 통해 상호작용한 아이템의 정보 표시

### 점프대
![image](https://github.com/user-attachments/assets/55cb3355-98af-4c9d-87f0-08b7ce1fc415)
이 오브젝트와 접촉시 OnCollisionEnter를 통해 접촉한 오브젝트는 위로 점프하도록 설정

### 아이템
![image](https://github.com/user-attachments/assets/24603df2-f2df-4839-a2b6-c38a811e85ae)
![image](https://github.com/user-attachments/assets/11a0ce1b-bbab-42d2-9cdf-fe37e3a96b2c)
ScriptableObject로 만든 아이템, 각 아이템마다 능력치가 다르며 상호작용 시 아이템 사용 가능
