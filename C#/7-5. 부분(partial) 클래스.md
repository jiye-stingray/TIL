# 7.5 부분(partial) 클래스
partial 예약어를 클래스에 적용하면 클래스의 소스코드를 2개 이상으로 나눌 수 있다. 예를 들어, 다음과 같이 정의된 클래스가 있다면 

```cs
class Person 
{
    string _name;
    int _age;

    public string Name {get {return _name;} set {_name = value;}}
    public int Age {get{return _age;} set {_age = value;}}
}
```
partial 예약어를 클래스에 적용하면 클래스의 소스코드를 2개 이상을 나눌 수 있다. 

```cs
partial class Person 
{
    string _name;
    public string Name {get {return _name;} set {_name = value;}}
}

partial class Person
{
    int _age;

    public int Age {get {return _age;} set {_age = value;}}
}
```

클래스 정의가 나뉜 코드는 한 파일에 있어도 되고 다른 파일로 나누는 것도 가능하지만 반드시 같은 프로젝트에서 컴파일 해야 한다. C# 컴파일러는 빌드 시에 같은 프로젝트에 있는 partial 클래스를 하나로 모아 단일 클래스로 빌드한다. 