using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
// �÷��̾��� �浹 ó���� ����ϴ� ��ũ��Ʈ.
public class PlayerTrigger : MonoBehaviour
{
    // �� ź���� �±�.
    [SerializeField] private string enemyBulletTag;
    // �÷��̾��� ü��.
    [SerializeField] private float hp = 100f;

    // �̺�Ʈ.
    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Vector3> OnPlayerDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyBulletTag))
        {
            // �� ź�� ����.
            Destroy(collision.gameObject);

            // �÷��̾ ������� �Ծ��ٴ� �̺�Ʈ ����.
            OnPlayerDamaged?.Invoke();

            // ����� ó��.
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;

            // ���� Ȯ�� �� �̺�Ʈ ����.
            if (hp == 0f)
            {
                // �̺�Ʈ ����.
                OnPlayerDead?.Invoke(transform.position);
                // �÷��̾� ���� ������Ʈ ����.(�� ��ũ��Ʈ�� �޸� ������Ʈ ����)
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
