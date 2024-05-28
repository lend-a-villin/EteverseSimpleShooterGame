using UnityEngine;

// �÷��̾��� �߻縦 �����ϴ� ��ũ��Ʈ.
public class PlayerShoot : MonoBehaviour
{
    // ź�� �߻� - ���� ����.

    // �ڵ����� �߻�ǵ��� ����� ����.
    // ź���� �߻�Ǵ� ����.
    [SerializeField] private float shootInterval = 0.2f;
    [SerializeField] private GameObject bulletPrefab;

    // �ִϸ��̼� ����.
    private Animator refAnimator;

    // �� ��� ���� (���� �ð� ���).
    private float elapsedTime = 0f;

    private void Awake()
    {
        refAnimator = GetComponent<Animator>();
        // �ڵ����� �ݺ� ����ǵ��� ����.
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    // �߻� �Լ�.
    void Update()
    {
        // Ÿ�̸� ������Ʈ.
        elapsedTime += Time.deltaTime;
        // Ÿ�̸Ӱ� �߻� ���� �ð���ŭ ��������,
        if (elapsedTime > shootInterval)
        {
            // �߻��ϰ�,
            Shoot();
            // Ÿ�̸� �ʱ�ȭ.
            elapsedTime = 0f;
        }
    }
    private void Shoot()
    {
        // �ִϸ��̼� Ʈ���� ����.
        refAnimator.SetTrigger("Shoot");

        if (bulletPrefab != null)
        {
            // ź �߻�.
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            // ����� �α״� ������ ���� �ʰ�, �����ص� �������� �ʴ´�.
            Debug.Log("<color=red> bulletPrefab ������ �������� �ʾҽ��ϴ�.</color>");
        }   
    }
}
