using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineMovement : MonoBehaviour
{
    public Transform[] soccerLines; // Alt objelerin referanslarını tutacak dizi
    public Transform[] endTransforms; // Hedef konumlar dizisi
    public GameObject[] objectsToColor; // Rengini değiştireceğimiz objelerin listesi

    public GameObject easyButtonEmptyObject;
    public GameObject normalButtonEmptyObject;
    public GameObject hardButtonEmptyObject;

    void Start()
    {
        if (soccerLines.Length != endTransforms.Length)
        {
            Debug.LogError("soccerLines ve endTransforms dizileri aynı uzunlukta değil!");
            return;
        }

        for (int i = 0; i < soccerLines.Length; i++)
        {
            MoveLine(soccerLines[i], endTransforms[i]);
        }

        foreach (GameObject obj in objectsToColor)
        {
            ChangeObjectColor(obj, GetRandomColor());
        }
    }

    void MoveLine(Transform line, Transform endTransform)
    {
        float duration = Random.Range(0.4f, 1f); // Hareket süresi

        if (easyButtonEmptyObject.activeSelf)
        {
            Debug.Log("Kolay seviye aktif! Oyun daha yavaş.");
            // Kolay seviye için ekstra işlemler ekle
            duration = Random.Range(.4f, .7f);
        }
        else if (normalButtonEmptyObject.activeSelf)
        {
            Debug.Log("Normal seviye aktif! Oyun normal hızda.");
            // Normal seviye için ekstra işlemler ekle
            duration = Random.Range(.2f, .6f);

        }
        else if (hardButtonEmptyObject.activeSelf)
        {
            Debug.Log("Zor seviye aktif! Oyun daha hızlı.");
            // Zor seviye için ekstra işlemler ekle
            duration = Random.Range(.1f, .3f);

        }
        // DOTween hareket animasyonunu oluştur
        line.DOMove(endTransform.position, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo); // Yoyo ile gidip gelme
    }

    Color GetRandomColor()
    {
        // Rastgele bir renk oluştur
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        return randomColor;
    }

    void ChangeObjectColor(GameObject obj, Color color)
    {
        // Renderer bileşenini al
        Renderer renderer = obj.GetComponent<Renderer>();

        // Eğer renderer bileşeni varsa
        if (renderer != null)
        {
            // Materyali al ve rengini değiştir
            Material material = renderer.material;
            material.color = color;
        }
        else
        {
            Debug.LogWarning(obj.name + " objesinde Renderer bileşeni bulunamadı!");
        }
    }
}
