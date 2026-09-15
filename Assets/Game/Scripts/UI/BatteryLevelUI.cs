using UnityEngine;
using UnityEngine.UI;
 
public class BatteryLevelUI : MonoBehaviour
{
    // Variable untuk reference object UI BatteryLevel
    [SerializeField]
    private GameObject _uiObject;
    // Variable untuk menentukan warna ketika lebel batre high
    [SerializeField]
    private Color _highColor = Color.white;
    // Variable untuk menentukan warna ketika lebel batre medium
    [SerializeField]
    private Color _mediumColor = Color.white;
    // Variable untuk menentukan warna ketika lebel batre low
    [SerializeField]
    private Color _lowColor = Color.white;
    // Variable untuk reference component Image Fill
    [SerializeField]
    private Image _batteryFill;
 
    // Function untuk memunculkan dan 
    // menyembunyikan object UI BatteryLevel
    public void SetVisibility(bool value)
    {
        // Mengubah status active berdasarkan 
        // parameter function (true: aktif/muncul/ false: tidak muncul)
        _uiObject?.SetActive(value);
    }
 
    // Function untuk mengubah fill dan warna level batre 
    public void UpdateBatteryUI(float value, float maxValue)
    {
        // Mendapatkan berapa persen batre flashlight saat ini
        // Memasukkan hasilnya ke variable fill amount
        float fillAmount = value / maxValue;
        // Mengubah fill amount battery level
        // dengan variable fill amount yang sebelumnya sudah dihitung
        _batteryFill.fillAmount = fillAmount;
        // Default warna fill battery level adalah high color
        Color color = _highColor;
        // Jika level battery kurang dari 25 persen
        if (fillAmount < 0.25f)
        {
            // Ganti warna jadi low color
            color = _lowColor;
        }
        // Jika level battery diantara 25 persen dan 50 persen
        else if (fillAmount > 0.25f && fillAmount < 0.5f)
        {
            // Ganti warna jadi medium color
            color = _mediumColor;
        }
        // Mengubah warna fill battery level
        // dengan variable color yang sudah ditentukan sebelumnya
        _batteryFill.color = color;
    }
}