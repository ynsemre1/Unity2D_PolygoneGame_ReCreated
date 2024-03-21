using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Oluşturulacak nesne
    public float spawnInterval = 1f; // Yeni nesneler arasındaki zaman aralığı
    public float spawnRadius = 4f; // Oluşturulan nesnenin rastgele konumlanacağı yarıçap

    private float spawnTimer; // Oluşturma zamanlayıcısı

    void Start()
    {
        // İlk nesneyi oluşturmak için spawnTimer'ı sıfırla
        spawnTimer = 0f;
    }

    void Update()
    {
        // spawnInterval süresi boyunca spawnTimer'ı arttır
        spawnTimer += Time.deltaTime;

        // spawnInterval süresi tamamlandığında yeni bir nesne oluştur
        if (spawnTimer >= spawnInterval)
        {
            // Nesneyi spawn et
            SpawnObject();

            // spawnTimer'ı sıfırla ve yeni bir spawn döngüsüne başla
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
{
    // Yüksekliği sabit tut
    float spawnY = transform.position.y;

    // X ekseni için rastgele bir konum belirle
    float spawnX = transform.position.x + Random.Range(-spawnRadius, spawnRadius);

    // Yeni bir konum oluştur
    Vector3 spawnPosition = new Vector3(spawnX, spawnY, transform.position.z);

    // Oluşturulacak nesneyi spawn et
    Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
}
}
