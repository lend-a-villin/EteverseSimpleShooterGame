using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���� �ִϸ��̼� �̺�Ʈ�� ó���� ��ũ��Ʈ.
public class Explosion : MonoBehaviour
{
    // �ִϸ��̼� �̺�Ʈ�� ������ �Լ�.
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
