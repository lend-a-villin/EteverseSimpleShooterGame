using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���� ����Ʈ�� �����Ű�� ��ũ��Ʈ.
public class ExplosionEffector : MonoBehaviour
{
    // ���� �ִϸ��̼��� ����� ������.
    [SerializeField] private GameObject explosion;
    public void PlayExplosionEffect(Vector3 explosionPosition)
    {
        // ���޹��� ��ġ�� explosion ������ ����.
        Instantiate(explosion, explosionPosition, Quaternion.identity);
    }
}
