using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// 플레이어의 발사를 제어하는 스크립트.
public class PlayerShoot : MonoBehaviour
{
    // 탄약 발사 - 게임 로직.

    // 자동으로 발사되도록 기능을 구현.
    // 탄약이 발사되는 간격.
    [SerializeField] private float shootInterval = 0.2f;
    
    // 플레이어 탄약 프리팹.
    [SerializeField] private GameObject bulletPrefab;

    // 탄약 발사 위치 트랜스폼.
    [SerializeField] private Transform firePosition;

    // 탄약을 발사할 때 발생시킬 이벤트 (타입: 유니티 이벤트). 이 구조가 좋은 구조가 아니다. 이걸 프라이빗으로 두고 이벤트 게터 세터처럼 하는 게 원칙적으로는 좋다.
    public UnityEvent OnShoot;

    // 초 계산 변수 (누적 시간 계산).
    private float elapsedTime = 0f;

    private void Awake()
    {
        // 자동으로 반복 실행되도록 예약.
        //InvokeRepeating("Shoot", 0f, shootInterval);

        //CancelInvoke("Shoot");
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
        OnShoot?.Invoke();

        // 위의 구문은 아래 주석과 같다.
        //if (OnShoot != null)
        //{
        //    OnShoot.Invoke();
        //}


        if (bulletPrefab != null)
        {
            // 탄 발사. Quaternion.identity는 0,0,0도(회전 안 함)다.
            Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        }
        else
        {
            // 디버그 로그는 성능이 좋지 않고, 빌드해도 삭제되지 않는다.
            Debug.Log("<color=red> bulletPrefab 변수가 설정되지 않았습니다.</color>");
        }   
    }
}
