### 시작하기 전에… !

때는 아주 오래전… 전국기능대회 준비 시절… 

타워디팬스게임에서 적이 정해진 경로를 따라 이동하는 기능을 구현해야했다.

그 때 처음 **Navmesh** 를 사용해보았다

---

### Navmesh란

<aside>
💡 길찾기 프로그램

</aside>

으로 총 3가지의 요소로 이루어져 있다

- Navmesh
- NavMeshAgent
- NavmeshObstacle

---

### Navmesh

[Window > AI > Navigation] 에 가면 `Navigation View` 가 열린다. 

그 뷰에는 

- Agent
    - 돌아다닐 객체의 크기나 오를 수 있는 경사로 등등 여러 항목들을 정할 수 있다
    - 기본 타입 뿐 아니라 다양한 타입을 추가할 수 있다.
- Area
    - 구역을 설정하고, 구역을 지나가는 비용을 설정할 수 있다
    - 비용이 적게 드는 곳 우선하여 이동한다 (물가나, 사막 등 다양한 환경 구축 가능)
- Bake
    - 구역으로 사용할 오브젝트를 선택하고 **굽는다**(Bake)
- Object
    - 씬의 오브젝트에 필터를 사용하여 필요한 오브젝트 만을 보여주게 한다

---

### NavmeshAgent

Navmesh 위에서 길을 찾아 움직일 오브젝트를 의미한다.

움직일 오브젝트에 NavmeshAgent 컴포넌트를 추가한다.

```csharp
using UnityEngine;
using UnityEngine.AI;   // 스크립트에서 내비게이션 시스템 기능을 사용하려면 AI 네임스페이스를 using 선언해야함

public class Moveable : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent agent;

    // 에이전트의 목적지
    [SerializeField]
    Transform target;

    private void Awake()
    {
        // 게임이 시작되면 게임 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져와서 저장
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 스페이스 키를 누르면 Target의 위치까지 이동하는 경로를 계산해서 이동
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 에이전트에게 목적지를 알려주는 함수
            agent.SetDestination(target.position);
        }
    }
}
출처: https://wergia.tistory.com/225 [베르의 프로그래밍 노트:티스토리]
```

`SetDestination(target.position)`함수로 이동할 위치를 정해준다.

- NavmeshObject의 프로퍼티
    - Base Offset
        - 길을 찾을 때 충돌되는 충돌 실린더의 위치
    - Speed
    - Angular Speed
        - 회전하는 속도
    - Acceleration
        - 가속도
    - Stopping Distance
        - 얼마만큼의 거리를 두고 멈출까
        - 원거리 유닛이 사정거리에 맞춰 멈추어 공격하게 할 수 있다
    - Auto Breaking
        - 목적지에 도착하기 전 감속을 시켜줄 것인가 ?
            - 이 걸 끄면 목적지에 도착하고 나서 부터 감속하기 때문에 속도를 주체하지 못하고 목적지를 넘어간 뒤 다시 목적지에 도착하기 위해서 계속 왔다갔다하는 모습을 볼 수 있다.
    - Radius
        - 지형과는 관계없이 다른 에이젼트와 NavmeshObstacle 과만 충돌하는 영역의 두께만 조절된다.
    - Height
        - 에이젼트끼리의 높이 충돌을 조절하는 프로퍼티이다.
    - Quality
        - 장애물 회피 품질을 의미한다
        - 양쪽다 None으로 설정하면 서로 완전히 무시하고 지나간다
    - Priority
        - 에이젼트 간의 우선순위이다.
        - 순위가 낮은 에이젼트를 전혀 고려하지 않고 밀어버린다. 같은 순위는 회피하려는 노력은 하지만 여기치 않으면 밀어버린다. 순위가 높은 오브젝트는 밀어내지 못한다
    - Auto Repath
        - 경로에 변경이 생겼을 때 자동으로 체크하는 기능이다
        - 먼거리를 이동할 때 중간에 경로가 변경된다면
            
            끊긴 경로까지 이동하고 다시 경로를 찾는 알고리즘을 작성해야함!
            
        
        ---
        
        ### NavmeshObstacle
        
        이동을 방해하는 장애물 역할을 하는 컴포넌트 
        
        static 과 다르게 이동하는 오브젝트에 사용