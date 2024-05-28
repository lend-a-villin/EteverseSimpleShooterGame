using UnityEngine;

// 플레이어의 발사를 제어하는 스크립트.
public class PlayerShoot : MonoBehaviour
{
    // 탄약 발사 - 게임 로직.

    // 자동으로 발사되도록 기능을 구현.
    // 탄약이 발사되는 간격.
    [SerializeField] private float shootInterval = 0.2f;
    [SerializeField] private GameObject bulletPrefab;

    // 애니메이션 제어.
    private Animator refAnimator;

    // 초 계산 변수 (누적 시간 계산).
    private float elapsedTime = 0f;

    private void Awake()
    {
        refAnimator = GetComponent<Animator>();
        // 자동으로 반복 실행되도록 예약.
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    // 발사 함수.
    void Update()
    {
        // 타이머 업데이트.
        elapsedTime += Time.deltaTime;
        // 타이머가 발사 간격 시간만큼 지났으면,
        if (elapsedTime > shootInterval)
        {
            // 발사하고,
            Shoot();
            // 타이머 초기화.
            elapsedTime = 0f;
        }
    }
    private void Shoot()
    {
        // 애니메이션 트리거 설정.
        refAnimator.SetTrigger("Shoot");

        if (bulletPrefab != null)
        {
            // 탄 발사.
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            // 디버그 로그는 성능이 좋지 않고, 빌드해도 삭제되지 않는다.
            Debug.Log("<color=red> bulletPrefab 변수가 설정되지 않았습니다.</color>");
        }   
    }
}
