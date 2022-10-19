using UnityEngine;

/// <summary>
/// 싱글톤 베이스 
/// </summary>
/// <typeparam name="T">Singleton 클래스를 상속받은 T타입만 올 수 있음</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    // 씬 변경 시 파괴하지 않을 건지
    public bool isDontDestroy;

    // 인스턴스 객체를 담을 필드
    private static T _instance;

    public static T Instance
    {
        get
        {
            // 인스턴스가 없는지 확인
            if (_instance == null)
            {
                // 없다면 씬에서 찾음
                _instance = FindObjectOfType(typeof(T)) as T;

                // 찾아도 없다면
                if (_instance == null)
                {
                    // 생성하여 T타입 컴포넌트를 붙임
                    var go = new GameObject(typeof(T).ToString());
                    _instance = go.AddComponent<T>();
                }
            }

            // 결과적으로 반환 시에는 인스턴스는 무조건 존재함
            return _instance;
        }
    }

    public virtual void Awake()
    {
        // Awake가 들어왔다는 것은 씬 장면의 하이라키상에 객체가 존재한다는 뜻
        // 이 때 경우는 2가지 -> 내가 미리 씬에 T타입 스크립트를 갖는 객체를 배치했거나
        //                      다른 스크립트를 통해 T타입 인스턴스에 접근하여 객체가 생성된 경우

        // 이 때 싱글톤 사용에 규칙성을 부여
        // ex) 난 무조건 싱글톤을 갖는 객체라면 씬에 미리 스크립트를 갖는 객체를 배치하는 식으로 사용한다

        // 위의 경우, 타 스크립트에서 awake 시점보다 빠른 시점에 t타입객체에 접근하지 않았다면
        // 인스턴스는 무조건 null임

        // 그럼 null이 아닌 경우, 씬에 t타입 객체가 하나 더 생성된 경우
        // 해당 객체를 파괴함으로써 결과적으로 단 하나의 인스턴스만을 유지할 수 있다.

        if (_instance == null)
        {
            _instance = this as T;

            if (isDontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}