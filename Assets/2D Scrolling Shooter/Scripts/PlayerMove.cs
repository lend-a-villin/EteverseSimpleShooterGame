using UnityEngine;

// 마우스 드래그(모바일-터치)를 사용해서 플레이어를 이동시키는 스크립트.
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float lagSpeed = 2f;
    // 카메라를 저장할 참조 변수.
    private Camera mainCamera;

    // 플레이어와 드래그 위치의 오프셋 값.
    private Vector3 offset;

    // 트랜스폼 참조 변수.
    [SerializeField] private Transform refTransform;

    private void Awake()
    {
        // 메인 카메라를 변수에 저장.
        mainCamera = Camera.main;
        refTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        // 마우스 클릭을 시작할 때 마우스 클릭 위치와 플레이어의 위치를 오프셋으로 계산.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;
            offset = refTransform.position - clickPosition;

        }

        // 마우스 클릭 시 반복.
        if (Input.GetMouseButton(0))
        {
            // 마우스 위치를 3차원 월드 좌표로 변환.
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // 오프셋을 보정해 이동해야 할 최종 위치를 일단 저장.
            Vector3 targetPosition = clickPosition + offset;

            // x축의 위치를 화면에서 벗어나지 않도록 설정.
            targetPosition.x = Mathf.Clamp(clickPosition.x, -1.3f, 1.3f);

            // y축의 위치를 화면에서 벗어나지 않도록 설정.
            targetPosition.y = Mathf.Clamp(clickPosition.y, -2.3f, 2.1f);

            // 3차원으로 변환을 거친 좌표를 플레이어 좌표로 설정.
            //offset = refTransform.position + clickPosition;
            // Lerp와 지연 시간을 이용하여 부드러운 이동.
            refTransform.position = Vector3.Lerp(refTransform.position, targetPosition, Time.deltaTime * lagSpeed);

        }

        // 클릭 해제 시 값 정리.
        if (Input.GetMouseButtonUp(0)) 
        {
            offset = Vector3.zero;
        }
    }
}
