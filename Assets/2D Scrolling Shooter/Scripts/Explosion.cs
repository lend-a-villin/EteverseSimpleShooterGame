using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���� �ִϸ��̼� �̺�Ʈ�� ó���� ��ũ��Ʈ.
public class Explosion : MonoBehaviour
{
    // �ִϸ��̼� �̺�Ʈ�� ������ �Լ�.
    // �ۺ����� ���� �ʿ� ����.
    // �ִϸ��̼��� ������ �ð��� �����ؼ� ������ ���� ������, �̷��� �ϸ� ��Ȯ�� ������ �ð��� ���𰡸� �߰��� �� �� �ִٴ� ������ �ִ�.
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
