using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 배경을 스크롤 시키는 스크립트.
public class BGScroller : MonoBehaviour
{
    // 메시 렌더러가 관리하는 머티리얼의 Offstet 값을 조정해야 함.
    [SerializeField] private MeshRenderer meshRenderer;
    //배경을 흘러가는 속도 값.
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
