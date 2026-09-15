using UnityEngine;
 
public class HUDManager : MonoBehaviour
{
    // Variable untuk reference ke module StaminaUI
    [SerializeField]
    private StaminaUI _staminaUI;
 
    // Variable untuk menyimpan reference  
    // instance/object HUDManager
    // variable ini akan disimpan diaplikasi game
    // dan akan tetap ada selama game nya berjalan
    private static HUDManager _instance;
     [SerializeField]
    private BatteryLevelUI _batteryLevelUI;
    [SerializeField]
    private InteractionInfoUI _interactionInfoUI;
    [SerializeField]
    private CrosshairUI _crosshairUI;
    // Membuat property untuk mengakses variable _crosshairUI
    public CrosshairUI CrosshairUI => _crosshairUI;
    // Membuat property untuk mengakses variable _interactionInfoUI
    public InteractionInfoUI InteractionInfoUI => _interactionInfoUI;
    // Membuat property untuk mengakses variable _batteryLevelUI
    public BatteryLevelUI BatteryLevelUI => _batteryLevelUI;
    // Membuat property untuk mengakses 
    // variable static _instance
    public static HUDManager Instance => _instance;
 
    // Membuat property untuk mengakses variable _staminaUI
    public StaminaUI StaminaUI => _staminaUI;
 
    private void Awake()
    {
        // Ketika game dimulai, mengecek apakah variable _instance
        // sudah ada reference ke object HUDManager?
        // ingat variable static akan disimpan di dalam game state
        // jadi variable nya sharing dengan object HUDManager lainnya
        // Jika sudah ada, artinya sudah ada object HUDManager
        // di scene. Hapus object ini supaya tidak ada lebih dari satu
        // HUDManager
        if (_instance != null)
        {
            // Jika _instance sudah ada reference ke object HUDManager
            // Hapus game object ini
            Destroy(gameObject);
            // Keluar dari function awake
            return;
        }
        // Tapi jika belum ada, maka isi variable dengan reference 
        // ke object ini
        _instance = this;
    }
}