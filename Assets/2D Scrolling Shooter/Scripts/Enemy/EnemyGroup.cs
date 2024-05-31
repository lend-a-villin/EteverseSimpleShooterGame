using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ڽ� ���� ������Ʈ�� ������ ������ �ϵ��� ó���ϴ� ��ũ��Ʈ.
public class EnemyGroup : MonoBehaviour
{
    private void Awake()
    {
        // ���������� Ȯ���ϴ� �޼ҵ�.
        InvokeRepeating("CheckChildState", 0f, 0.5f);
    }

    // �ʹ� ���� Ȯ���ϹǷ� ��ü�� ������ ���� ���ϰ� ���� ����.
    //private void Update()
    //{
    //    CheckChildState();
    //}

    // �ڽ� ���� ������Ʈ�� �ִ��� ������ Ȯ���ϴ� �Լ�.
    private void CheckChildState()
    {
        // �ڽ��� ������ ���� ������Ʈ ����.
        if (transform.childCount == 0)
        {
            // �ݺ� Ȯ�� ����ϱ�.
            // �� �ص� �Ǳ� ������ ���������� ������ ����.
            // �⺻������ �ڷ�ƾ���� ���µ�, ���� ������Ʈ�� ����־�� ����.
            // ����ó�� ���� ������Ʈ�� �����Ǹ� �˾Ƽ� �״µ�, �ڷ�ƾ�̸� ����Ƽ�� �˾Ƽ� �׿��ִµ�, �κ�ũ�� ���������� �ణ �ٸ��� ������ �Ѵ�.
            // ���� ų ����Ʈ�� �ö��ִµ�, ��Ȥ �κ�ũ�� �ҷ������鼭 ������ ���� ��찡 �ִ�.
            // ���� ������Ʈ�� �׾��µ� �κ�ũ�� ȣ���ߴٸ�.
            CancelInvoke("CheckChildState");
            // �ı�.
            Destroy(gameObject);
        }
    }
}
