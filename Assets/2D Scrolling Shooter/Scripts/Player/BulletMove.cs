using UnityEngine;
// ź���� �̵���Ű�� ��ũ��Ʈ.
public class BulletMove : MonoBehaviour
{
    // ź���� �̵� �ӵ�.
    [SerializeField] private float moveSpeed = 10f;

    // Ʈ������ ������Ʈ ���� ����. �������� �Ͼ�� �ʵ��� ������ �صΰ� ����ϴ� ���� ����.
    private Transform refTransform;

    void Awake()
    {
        refTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ӵ� �.
        refTransform.position += refTransform.up * moveSpeed * Time.deltaTime;
    }
}
