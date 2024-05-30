using UnityEngine;
// 탄약을 이동시키는 스크립트.
public class BulletMove : MonoBehaviour
{
    // 탄약의 이동 속도.
    [SerializeField] private float moveSpeed = 10f;

    // 트랜스폼 컴포넌트 참조 변수. 마샬링이 일어나지 않도록 저장을 해두고 사용하는 것이 좋다.
    private Transform refTransform;

    void Awake()
    {
        refTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 등속도 운동.
        refTransform.position += refTransform.up * moveSpeed * Time.deltaTime;
    }
}
