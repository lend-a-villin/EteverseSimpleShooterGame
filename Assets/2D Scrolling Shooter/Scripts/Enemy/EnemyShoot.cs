using UnityEngine;
// 적 우주선의 탄약 발사를 처리하는 스크립트.
public class EnemyShoot : MonoBehaviour
{
    // 필드.
    // 필드 배치에는 정답이 있다. 16byte 단위로 끊으면 좋다.
    // 왜냐하면 16byte가 안 되면 유니티가 내부적으로 padding을 붙여서 16byte로 만든다.
    // SIMD와 MMX, SS2명령어 등의 CPU 계산기가 있는데, 거기에 집어넣어주기 때문이다.
    // 그래서 지금의 경우엔 4byte 손실을 보는 것이다. 하지만 우리는 지금 가능한 상태가 아니기 때문에 그냥 두면 된다.
    // 우리에겐 강제사항이 아니지만 쉐이더에선 강제사항이다. 오류 난다.
    
    // 발사 간격 (딜레이, 단위: 초).
    [SerializeField] private float shootInterval = 1.0f;
    // 탄약의 속력.
    [SerializeField] private float bulletSpeed = 3.0f;
    // 탄약 프리팹 연결.
    [SerializeField] private GameObject bulletPrefab;

    // 플레이어의 트랜스폼을 참조하는 변수.
    private Transform refPlayer;

    // 경과 시간을 계산하는 변수.
    private float elapesdTime = 0f;

    private void Awake()
    {
        // 플레이어 게임 오브젝트를 검색한 뒤에 refPlayer에 트랜스폼 저장.
        // 이름으로 찾는 것도 가능하긴 하지만 좋지 않다.
        // 그래서 우리는 유니티가 제공하는 플레이어 태그를 이용해 볼 것이다.
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
        // 타이머 업데이트.
        elapesdTime += Time.deltaTime;

        // 발사 간격 시간만큼 지났으면 탄약 발사.
        if (elapesdTime > shootInterval)
        {
            // 탄약 발사.
            Shoot();
            // 타이머 변수 초기화.
            elapesdTime = 0f;
        }
    }

    // 발사 메소드.
    private void Shoot()
    {
        // 플레이어의 위치를 향하는 방향 구하기.
        // 검증.
        if (refPlayer == null)
        {
            return;
        }
        // 벡터의 덧셈과 뺄셈을 공부해두면 좋다. 그냥 빼기일 경우에 뒤에 것에서 앞의 것을 향하는 방향이 생성된다는 정도만 알아도 된다.
        Vector3 direction = refPlayer.position - transform.position;

        // 프리팹을 이용해 탄약을 생성하고, 
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // 이런 식으로 변속을 줄 수 있다. 대미지에도 이런 식으로 변주를 줄 수 있다.
        float speed = Random.Range(bulletSpeed * 0.8f, bulletSpeed * 1.2f);
        // rigidbody2d 컴포넌트에 속도(빠르기(스칼라), 방향(벡터)) 설정.
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
    // 
}
