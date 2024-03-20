using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Beşgenin çizgilerini temsil eden GameObject dizisi
    public Rigidbody2D ballRigidbody; // Topun Rigidbody bileşeni
    public float baslangicKuvvet = 3f; // Topun baslangic itme kuvveti
    public HealthManager[] targetScriptReference; //HealthManager scripti için referans

    bool baslangicItildi = false; // Başlangıçta itme işlemi gerçekleşti mi?

    public GameObject[] renkObjects;

    public float minSpeed = 5f;
    public float maxSpeed = 10f;

    public TrailRenderer trailRenderer;

    private Renderer topRenderer;

    void Start()
    {
        // Topun Renderer bileşenini al
        topRenderer = GetComponent<Renderer>();

        // Trail Renderer bileşenini al
        if (trailRenderer == null)
        {
            // Eğer Trail Renderer atanmadıysa, oyun nesnesinden al
            trailRenderer = GetComponent<TrailRenderer>();
        }
    }

    void Update()
    {
        // BallScript içerisinde HealthManager referansına ulaş
        // Bu referans üzerinden EndGame fonksiyonunu çağırabilirsin
        foreach (HealthManager healthManager in targetScriptReference)
        {
            if (healthManager.gameEnded)
            {
                // Oyun bitti
                BaslangicYonu();
            }
        }

        // Topun rengini al
        Color topRengi = topRenderer.material.color;

        // Trail Renderer'in rengini güncelle
        trailRenderer.startColor = topRengi;
        trailRenderer.endColor = topRengi;
    }

    void FixedUpdate()
    {
        // Objenin hızını sınırlama
        float currentSpeed = ballRigidbody.velocity.magnitude;
        if (currentSpeed < minSpeed)
        {
            ballRigidbody.velocity = ballRigidbody.velocity.normalized * minSpeed;
        }
        else if (currentSpeed > maxSpeed)
        {
            ballRigidbody.velocity = ballRigidbody.velocity.normalized * maxSpeed;
        }
    }

    void BaslangicYonu()
    {
        if (!baslangicItildi)
        {
            // Rastgele bir yön belirle (sağa veya sola)
            float direction = Random.Range(0, 2) == 0 ? -1 : 1;
            // Başlangıç kuvvetini hesapla
            Vector2 initialForce = new Vector2(direction * baslangicKuvvet, 0f);
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = 0f;
            // Topa başlangıç kuvvetini uygula
            ballRigidbody.AddForce(initialForce, ForceMode2D.Impulse);
            baslangicItildi = true; // Başlangıç itme işlemi tamamlandı
            Debug.Log("Baslangic Kuvveti Uygulandi");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Temas edilen objenin renk objeleri arasında olup olmadığını kontrol et
        foreach (GameObject renkObject in renkObjects)
        {
            if (other.gameObject == renkObject)
            {
                Renderer otherRenderer = other.GetComponent<Renderer>();
                if (otherRenderer != null)
                {
                    // Temas edilen objenin rengini al ve topun rengini ona ayarla
                    ChangeObjectColor(gameObject, otherRenderer.material.color);
                    return; // Doğru objeyi bulduğumuzda döngüden çık
                }
                else
                {
                    Debug.Log("??? " + other.gameObject.name + " objesinde Renderer bileşeni bulunamadı!");
                }
            }
        }
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
