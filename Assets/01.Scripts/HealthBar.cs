using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform _barTrm;

    private void Awake()
    {
        _barTrm = transform.Find("Bar");
    }
    public void SetBarScale(float normalizedScale)
    {
        Vector3 scale = _barTrm.localScale;
        scale.x = Mathf.Clamp(normalizedScale, 0, 1f);
        _barTrm.localScale = scale;
    }
}
