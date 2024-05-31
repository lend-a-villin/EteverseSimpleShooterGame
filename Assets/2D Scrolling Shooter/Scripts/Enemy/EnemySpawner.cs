using System;
using UnityEngine;
// �� ĳ���� �׷��� ������ �ð� ���ݸ��� ������ x�࿡ �����ϴ� �� ������ ��ũ��Ʈ.
public class EnemySpawner : MonoBehaviour
{
 // �� ĳ���� ����(���� �߿� ����) ����.
        [Serializable]
    public class EnemySpawnInfo
    {
        // ������ �� ĳ���� �׷� ������.
        [SerializeField] private GameObject prefab;
        // �����ϱ���� ����� ���� �ð�(����: ��).
        [SerializeField] private float spawnTime;
        
        public GameObject Prefab { get { return prefab; } }
        public float SpawnTime { get { return spawnTime; } }

    }

    // �� ĳ���� ���� ���� �迭 ����.
    // ����Ƽ���� �迭 �� ���, ����Ƽ�� �˾Ƽ� �������ش�.
    [SerializeField] private EnemySpawnInfo[] spawnInfo;

    // �� ������ ����� �迭 �ε���.
    private int currentIndex = 0;

    private void Awake()
    {
        Invoke("Spawn", spawnInfo[currentIndex].SpawnTime);
    }

    // ������ �� �׷��� �����ϴ� �Լ�.
    private void Spawn()
    {
        // �������� ���� ����.
        Instantiate(spawnInfo[currentIndex].Prefab, transform.position,Quaternion.identity);
        // �迭 �ε��� ������Ʈ.
        currentIndex = (currentIndex + 1) % spawnInfo.Length;
        // ���� Spawn �Լ� ȣ�� ���.
        Invoke("Spawn", spawnInfo[currentIndex].SpawnTime);
        // ���� �ڵ尡 �� ���� ���� ���� �������� �ֽ��ϰ� �ִٰ�, �� ��� �ϴ� ��쿡�� ���� ���� ����϶�(�ߺ� �ڵ� ���̱� ����).
    }
}
