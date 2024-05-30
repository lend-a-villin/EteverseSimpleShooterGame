using UnityEngine;
using UnityEngine.Events;

// 플레이어/ 플레이어 탄약과 충돌 처리를 담당할 스크립트.
public class EnemyTrigger : MonoBehaviour
{
    // 충돌 처리할 플레이어 탄약 태그.
    [SerializeField] private string playerBulletTag;

    // 체력.
    [SerializeField] private float hp = 50f;

    // 대미지 이벤트.
    public UnityEvent OnDamaged;
    // 죽음 이벤트
    public UnityEvent<Vector3> OnDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 무언가와 충돌을 했으면, 태그를 비교.
        if (collision.CompareTag(playerBulletTag))
        {
            // 일단 탄약을 제거한다.
            Destroy(collision.gameObject);

            // 대미지를 받았다는 이벤트 발행.
            OnDamaged?.Invoke();

            // 대미지 처리 공식 적용. 하지만 이건 굉장히 위험한 코드다. BulletDamage를 가지고 있는지 확인하고 넣도록 하는 것이 좋다.
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;
            // 체력을 모두 소진했으면 죽음.
            if (hp == 0f)
            {
                // 죽음 이벤트 발행.
                OnDead?.Invoke(transform.position);
                // 삭제.
                Destroy(gameObject);
            }
        }
    }


    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
