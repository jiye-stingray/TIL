    public Transform Target;            //목표지점
    public float firingAngle = 45.0f;   //각도
    public float gravity = 9.8f;        //중력

    public Transform Projectile;        //투사체
    private Transform myTransform;      //투사체 위치

    void Start()
    {
        StartCoroutine(Parabolicprojection());
    }

    IEnumerator Parabolicprojection()
    {
        // 발사체를 던지기 전에 짧은 지연시간 
        yield return new WaitForSeconds(1.5f);

        // 투사체를 물체를 던지는 위치로 이동하고 필요한 경우 offset을 추가합니다.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // 대상까지의 거리 계산
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // 물체를 지정된 각도로 목표물에 던지는 데 필요한 속도를 계산합니다.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // 속도의 X,Y 추출
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // 비행 시간을 계산한다
        float flightDuration = target_Distance / Vx;

        // 발사체를 회전 시켜 목표물을 향하게 한다
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }

    }   