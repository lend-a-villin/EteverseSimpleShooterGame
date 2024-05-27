using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����� ��ũ�� ��Ű�� ��ũ��Ʈ.
public class BGScroller : MonoBehaviour
{
    // ��ũ�� ������ ������ �� �ֵ��� �ϴ� ������.
    public enum Direction
    {
        Up,
        Down
    }

    
    // ��� ��ũ�� ���� ���� ����.
    [SerializeField] private Direction direction = Direction.Down;

    // �޽� �������� �����ϴ� ��Ƽ������ Offstet ���� �����ؾ� ��.
    [SerializeField] private MeshRenderer meshRenderer;
    
    //����� �귯���� �ӵ� ��.
    [SerializeField] private float ySpeed = 0.1f;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        // ��ũ�ѿ� ������ ���� ��ȣ�� ����.
        float finalScroll = direction == Direction.Down ? ySpeed : -ySpeed;

        //��Ƽ������ �����ϴ� �ؽ�ó�� Offset �� �� Y ���� ����.
        meshRenderer.material.mainTextureOffset += new Vector2(0f, finalScroll) * Time.deltaTime;
    }

}
