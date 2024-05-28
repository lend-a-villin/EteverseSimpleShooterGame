using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������ �ð��� ������ ���� ������Ʈ�� �ڵ� �������ִ� ��ũ��Ʈ.
public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 1f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
