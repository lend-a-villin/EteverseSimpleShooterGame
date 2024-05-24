using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����� ��ũ�� ��Ű�� ��ũ��Ʈ.
public class BGScroller : MonoBehaviour
{
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
        meshRenderer.material.mainTextureOffset += new Vector2(0f, ySpeed) * Time.deltaTime;
    }

}
