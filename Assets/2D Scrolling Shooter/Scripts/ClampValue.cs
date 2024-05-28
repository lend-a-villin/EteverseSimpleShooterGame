using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class ClampValue : MonoBehaviour
{
    // ������ ������ �� ����� �ּҰ�.
    [SerializeField] private float min;

    // ������ ������ �� ����� �ִ밪.
    [SerializeField] private float max;

    public float Min { get { return min; } }
    public float Max { get { return max; } }
}