using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class RelayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _joinCodeText;
    [SerializeField] private TMP_InputField _joinCodeInputField;
    // Start is called before the first frame update
    // Start, oyun başladığında ilk çalışan fonksiyondur
    async void Start()
    {
        // Unity hizmetlerini başlat ve anonim olarak oturum aç
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    // Relay sunucusu üzerinden oyun başlatma
    public async void StartRelay()
    {
        // Host olarak Relay sunucusu ile bağlantı kur ve katılım kodunu al
        string joinCode = await StartHostWithRelay();
        // Katılım kodunu UI bileşenine yazdır
        _joinCodeText.text = joinCode;
    }

    // Relay sunucusuna katılma
    public async void JoinRelay()
    {
        // Giriş yapılan katılım kodunu kullanarak client olarak Relay sunucusuna bağlan
        await StartClientWithRelay(_joinCodeInputField.text);
    }

    // Host olarak Relay sunucusunu başlatma işlemi
    private async Task<string> StartHostWithRelay(int maxConnections = 3)
    {
        // Relay sunucusunda belirli sayıda bağlantı için bir tahsis oluştur
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
        // NetworkManager'daki UnityTransport bileşenine Relay sunucu verilerini ayarla
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

        // Katılım kodunu al
        string _joinCodeText = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        // Host başlatıldıysa katılım kodunu döndür, aksi halde null döndür
        return NetworkManager.Singleton.StartHost() ? _joinCodeText : null;
    }

    // Client olarak Relay sunucusuna katılma işlemi
    private async Task<bool> StartClientWithRelay(string joinCode)
    {
        // Verilen katılım kodunu kullanarak Relay sunucusuna katıl
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
        // NetworkManager'daki UnityTransport bileşenine Relay sunucu verilerini ayarla
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

        // Katılım kodu geçerliyse ve client başarılı bir şekilde başlatıldıysa true döndür, aksi halde false döndür
        return !string.IsNullOrEmpty(joinCode) && NetworkManager.Singleton.StartClient();
    }
}
