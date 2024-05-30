using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 폭발 애니메이션 이벤트를 처리할 스크립트.
public class Explosion : MonoBehaviour
{
    // 애니메이션 이벤트와 연동할 함수.
    // 퍼블릭으로 만들 필요 없다.
    // 애니메이션이 끝나는 시간을 짐작해서 삭제할 수도 있지만, 이렇게 하면 정확히 끝나는 시간에 무언가를 추가로 할 수 있다는 장점이 있다.
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
