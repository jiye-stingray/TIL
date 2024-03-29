# ADR 이란 ?
ADR(Architectural Decision Records)은 **아키텍쳐와 관련된 결정을 내렸을 때 그 과정을 기록해 두는 문서**

ADR은 간단한 양식을 통해 마크다운 형식으로 작성된다. 
문제 정의, 결정에 영향을 주는 기본 요구사항, 설계 결정등의 내용이 포함되어 있다. 

## 왜 필요한가? 
협업을 하는 이상 어떤 방식으로든 팀원들과 함께 의사결정하고 공유하게 된다. 그러다 새로운 팀원이 히스토리에 대해 묻는다면 기억을 더듬어 당시에 왜 그렇게 했는지 설명해야 한다. 
> 실제로 [TransTrash](https://github.com/SmarteenApp/Stac_Game) 라는 게임 작업중,
기존 팀원이 나가고 새로운 팀원이 들어왔었는데, 기존 작업물을 인수인계 받아야 하는 상황이 있었다. 이때 작업물만 있고 다른 기록들이 없다보니, 기존 코드를 이해하고 팀 협업 규칙들을 파악하는데 꽤 오랜 시간이 소요되었다. ADR를 공부하는 이유이기도 하다. 

### 장점

**명확하고 합리적인 의사 결정을 내릴 수 있다**
정의된 ADR 탬플릿에 따라 문서화하면 일관된 방식으로 의사결정할 수 있습니다. 저자는 문서를 작성하는 과정에서 더 합리적인 결론을 도출해낼 수 있으며 독자는 문제에 대해 쉽게 이해할 수 있다

**새로운 팀원이 적응하는데 많은 도움이 됩니다**
새로운 팀원이 들어오면 새로운 개발환경, 아키텍쳐를 이해하기까지 많은 시간을 할애한다. 만약 ADR을 통해 과거 의사결정 과정까지 알게 된다면 더 쉽게 이해할 수 있다.

## ADR Template
ADR 형식은 정하기 나름이지만 이 글에서는 가장 알려진 템플릿을 기준으로 설명하겠다. architecture-decision-record Github에서 더 다양한 템플릿과 예시 문서를 확인할 수 있다.

#### 1. Status
![](https://velog.velcdn.com/images/stingray/post/9f51488c-5ceb-4924-bbc1-7d02c2e5f444/image.png)

먼저 Status는 위와 같은 상태 다이어그램으로 표현되며 현재 문서의 상태를 나타낸다 

#### 2. Context
Context는 해결하고자 하는 문제를 정의하는 목차다. 

#### 3. Decision
![](https://velog.velcdn.com/images/stingray/post/14fd6e93-1451-417c-90bd-42db43d47c78/image.png)
Decision에서는 제안하고자 하는 내용 및 해당 결정의 이유에 대해 설명한다. 예를 들어 이 결정이 도입된다면 어떤 효과가 나타날 수 있는지에 대해 설명할 수 있다.
위와 같이 간단히 비교하는 표를 추가하면 읽는 사람이 더 쉽게 이해할 수 있다.

#### 4. Consequences 
Consequences에서는 결정을 통해 사용자가 받는 영향에 대해 정의한다. 예를 들어 이 결정이 도입된다면 어떤 효과가 나타날 수 있는지에 대한 영향을 정리할 수 있다.

### 마지막으로..
새로 도입할 때는 ADR이 부담스러운 업무가 되지 않도록 가능한 가볍게 유지할 수 있어야 한다. 
ADR은 나를 위한 것이 아니라 현재 그리고 미래의 팀원들을 위한 것이라고 한다. 

[참고자료](https://swalloow.github.io/feat-adr/)
