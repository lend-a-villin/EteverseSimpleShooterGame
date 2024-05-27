using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 배경을 스크롤 시키는 스크립트.
public class BGScroller : MonoBehaviour
{
    // 스크롤 방향을 지정할 수 있도록 하는 열거형.
    public enum Direction
    {
        Up,
        Down
    }

    
    // 배경 스크롤 방향 지정 변수.
    [SerializeField] private Direction direction = Direction.Down;

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
        // 스크롤에 적용할 값의 부호를 결정.
        float finalScroll = direction == Direction.Down ? ySpeed : -ySpeed;

        //머티리엘이 관리하는 텍스처의 Offset 값 중 Y 값을 조정.
        meshRenderer.material.mainTextureOffset += new Vector2(0f, finalScroll) * Time.deltaTime;
    }

}
