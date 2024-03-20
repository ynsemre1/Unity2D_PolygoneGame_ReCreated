using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineMovementDoTween : MonoBehaviour
{
    public Transform endTransform;

    void Start()
    {
        float duration = Random.Range(0.4f, 1f); // Hareket süresi
        // DOTween hareket animasyonunu oluştur
        transform.DOMove(endTransform.position, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo); // Yoyo ile gidip gelme
    }
}
