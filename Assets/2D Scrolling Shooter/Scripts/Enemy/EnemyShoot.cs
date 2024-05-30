using UnityEngine;
// �� ���ּ��� ź�� �߻縦 ó���ϴ� ��ũ��Ʈ.
public class EnemyShoot : MonoBehaviour
{
    // �ʵ�.
    // �ʵ� ��ġ���� ������ �ִ�. 16byte ������ ������ ����.
    // �ֳ��ϸ� 16byte�� �� �Ǹ� ����Ƽ�� ���������� padding�� �ٿ��� 16byte�� �����.
    // SIMD�� MMX, SS2��ɾ� ���� CPU ���Ⱑ �ִµ�, �ű⿡ ����־��ֱ� �����̴�.
    // �׷��� ������ ��쿣 4byte �ս��� ���� ���̴�. ������ �츮�� ���� ������ ���°� �ƴϱ� ������ �׳� �θ� �ȴ�.
    // �츮���� ���������� �ƴ����� ���̴����� ���������̴�. ���� ����.
    
    // �߻� ���� (������, ����: ��).
    [SerializeField] private float shootInterval = 1.0f;
    // ź���� �ӷ�.
    [SerializeField] private float bulletSpeed = 3.0f;
    // ź�� ������ ����.
    [SerializeField] private GameObject bulletPrefab;

    // �÷��̾��� Ʈ�������� �����ϴ� ����.
    private Transform refPlayer;

    // ��� �ð��� ����ϴ� ����.
    private float elapesdTime = 0f;

    private void Awake()
    {
        // �÷��̾� ���� ������Ʈ�� �˻��� �ڿ� refPlayer�� Ʈ������ ����.
        // �̸����� ã�� �͵� �����ϱ� ������ ���� �ʴ�.
        // �׷��� �츮�� ����Ƽ�� �����ϴ� �÷��̾� �±׸� �̿��� �� ���̴�.
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            refPlayer = player.transform;
        }
        else
        {
            Debug.Log("cannot find player transform!");
        }

        
    }

    private void Update()
    {
        // Ÿ�̸� ������Ʈ.
        elapesdTime += Time.deltaTime;

        // �߻� ���� �ð���ŭ �������� ź�� �߻�.
        if (elapesdTime > shootInterval)
        {
            // ź�� �߻�.
            Shoot();
            // Ÿ�̸� ���� �ʱ�ȭ.
            elapesdTime = 0f;
        }
    }

    // �߻� �޼ҵ�.
    private void Shoot()
    {
        // �÷��̾��� ��ġ�� ���ϴ� ���� ���ϱ�.
        // ����.
        if (refPlayer == null)
        {
            return;
        }
        // ������ ������ ������ �����صθ� ����. �׳� ������ ��쿡 �ڿ� �Ϳ��� ���� ���� ���ϴ� ������ �����ȴٴ� ������ �˾Ƶ� �ȴ�.
        Vector3 direction = refPlayer.position - transform.position;

        // �������� �̿��� ź���� �����ϰ�, 
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // �̷� ������ ������ �� �� �ִ�. ��������� �̷� ������ ���ָ� �� �� �ִ�.
        float speed = Random.Range(bulletSpeed * 0.8f, bulletSpeed * 1.2f);
        // rigidbody2d ������Ʈ�� �ӵ�(������(��Į��), ����(����)) ����.
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
    // 
}
