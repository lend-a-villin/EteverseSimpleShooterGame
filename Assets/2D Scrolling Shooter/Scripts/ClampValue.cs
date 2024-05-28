using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class ClampValue : MonoBehaviour
{
    // 범위를 지정할 때 사용할 최소값.
    [SerializeField] private float min;

    // 범위를 지정할 때 사용할 최대값.
    [SerializeField] private float max;

    public float Min { get { return min; } }
    public float Max { get { return max; } }
}