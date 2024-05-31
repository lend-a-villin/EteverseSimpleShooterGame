using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 자식 게임 오브젝트가 없으면 삭제를 하도록 처리하는 스크립트.
public class EnemyGroup : MonoBehaviour
{
    private void Awake()
    {
        // 간헐적으로 확인하는 메소드.
        InvokeRepeating("CheckChildState", 0f, 0.5f);
    }

    // 너무 자주 확인하므로 개체가 많으면 성능 저하가 오기 쉽다.
    //private void Update()
    //{
    //    CheckChildState();
    //}

    // 자식 게임 오브젝트가 있는지 없는지 확인하는 함수.
    private void CheckChildState()
    {
        // 자식이 없으면 게임 오브젝트 삭제.
        if (transform.childCount == 0)
        {
            // 반복 확인 취소하기.
            // 안 해도 되긴 하지만 간헐적으로 문제가 생김.
            // 기본적으로 코루틴으로 도는데, 게임 오브젝트가 살아있어야 돈다.
            // 지금처럼 게임 오브젝트가 삭제되면 알아서 죽는데, 코루틴이면 유니티가 알아서 죽여주는데, 인보크는 내부적으로 약간 다르게 관리를 한다.
            // 예약 킬 리스트에 올라가있는데, 간혹 인보크가 불러와지면서 오류가 나는 경우가 있다.
            // 게임 오브젝트는 죽었는데 인보크를 호출했다며.
            CancelInvoke("CheckChildState");
            // 파괴.
            Destroy(gameObject);
        }
    }
}
