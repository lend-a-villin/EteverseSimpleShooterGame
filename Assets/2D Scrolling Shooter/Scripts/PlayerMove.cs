using UnityEngine;

// ���콺 �巡��(�����-��ġ)�� ����ؼ� �÷��̾ �̵���Ű�� ��ũ��Ʈ.
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float lagSpeed = 2f;
    // ī�޶� ������ ���� ����.
    private Camera mainCamera;

    // �÷��̾�� �巡�� ��ġ�� ������ ��.
    private Vector3 offset;

    // Ʈ������ ���� ����.
    [SerializeField] private Transform refTransform;

    private void Awake()
    {
        // ���� ī�޶� ������ ����.
        mainCamera = Camera.main;
        refTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        // ���콺 Ŭ���� ������ �� ���콺 Ŭ�� ��ġ�� �÷��̾��� ��ġ�� ���������� ���.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;
            offset = refTransform.position - clickPosition;

        }

        // ���콺 Ŭ�� �� �ݺ�.
        if (Input.GetMouseButton(0))
        {
            // ���콺 ��ġ�� 3���� ���� ��ǥ�� ��ȯ.
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // �������� ������ �̵��ؾ� �� ���� ��ġ�� �ϴ� ����.
            Vector3 targetPosition = clickPosition + offset;

            // x���� ��ġ�� ȭ�鿡�� ����� �ʵ��� ����.
            targetPosition.x = Mathf.Clamp(clickPosition.x, -1.3f, 1.3f);

            // y���� ��ġ�� ȭ�鿡�� ����� �ʵ��� ����.
            targetPosition.y = Mathf.Clamp(clickPosition.y, -2.3f, 2.1f);

            // 3�������� ��ȯ�� ��ģ ��ǥ�� �÷��̾� ��ǥ�� ����.
            //offset = refTransform.position + clickPosition;
            // Lerp�� ���� �ð��� �̿��Ͽ� �ε巯�� �̵�.
            refTransform.position = Vector3.Lerp(refTransform.position, targetPosition, Time.deltaTime * lagSpeed);

        }

        // Ŭ�� ���� �� �� ����.
        if (Input.GetMouseButtonUp(0)) 
        {
            offset = Vector3.zero;
        }
    }
}
