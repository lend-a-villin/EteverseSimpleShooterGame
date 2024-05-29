using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �� ���ּ��� ����� ȿ���� ������ �� ����� ��ũ��Ʈ.
public class EnemyEffector : MonoBehaviour
{
    // �ʵ�.

    // ������ �����̴� �ִϸ��̼��� ����ϴ� �ð� (����: ��).
    [SerializeField] private float colorAnimationInterval = 0.1f;

    // ��������Ʈ ������ ���� ������Ʈ.
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
    spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // ���� �޼ҵ� - �������̽�.
    public void PlayDamageEffect()
    {
        StartCoroutine(PlayDamageAnimation());
    }

    // Update is called once per frame
    private IEnumerator PlayDamageAnimation()
    {
        // ��������Ʈ �������� ������ ���������� ����.
        spriteRenderer.color = Color.red;

        // ���.
        yield return new WaitForSeconds(colorAnimationInterval);

        // ��������Ʈ �������� ������ ������� ����.
        spriteRenderer.color = Color.white;
    }
}
