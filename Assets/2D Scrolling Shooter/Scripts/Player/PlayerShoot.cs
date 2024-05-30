using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// �÷��̾��� �߻縦 �����ϴ� ��ũ��Ʈ.
public class PlayerShoot : MonoBehaviour
{
    // ź�� �߻� - ���� ����.

    // �ڵ����� �߻�ǵ��� ����� ����.
    // ź���� �߻�Ǵ� ����.
    [SerializeField] private float shootInterval = 0.2f;
    
    // �÷��̾� ź�� ������.
    [SerializeField] private GameObject bulletPrefab;

    // ź�� �߻� ��ġ Ʈ������.
    [SerializeField] private Transform firePosition;

    // ź���� �߻��� �� �߻���ų �̺�Ʈ (Ÿ��: ����Ƽ �̺�Ʈ). �� ������ ���� ������ �ƴϴ�. �̰� �����̺����� �ΰ� �̺�Ʈ ���� ����ó�� �ϴ� �� ��Ģ�����δ� ����.
    public UnityEvent OnShoot;

    // �� ��� ���� (���� �ð� ���).
    private float elapsedTime = 0f;

    private void Awake()
    {
        // �ڵ����� �ݺ� ����ǵ��� ����.
        //InvokeRepeating("Shoot", 0f, shootInterval);

        //CancelInvoke("Shoot");
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
        OnShoot?.Invoke();

        // ���� ������ �Ʒ� �ּ��� ����.
        //if (OnShoot != null)
        //{
        //    OnShoot.Invoke();
        //}


        if (bulletPrefab != null)
        {
            // ź �߻�. Quaternion.identity�� 0,0,0��(ȸ�� �� ��)��.
            Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        }
        else
        {
            // ����� �α״� ������ ���� �ʰ�, �����ص� �������� �ʴ´�.
            Debug.Log("<color=red> bulletPrefab ������ �������� �ʾҽ��ϴ�.</color>");
        }   
    }
}
