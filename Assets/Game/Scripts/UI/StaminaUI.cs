using UnityEngine;
using UnityEngine.UI;
 
public class StaminaUI : MonoBehaviour
{
    // Variable untuk reference object UI StaminaBar
    [SerializeField]
    private GameObject _uiObject;
    // Variable untuk reference component Image Fill
    [SerializeField]
    private Image _staminaFill;
 
    // Function untuk memunculkan dan 
    // menyembunyikan object UI StaminaBar
    public void SetVisible(bool value)
    {
        // Mengubah status active berdasarkan 
        // parameter function (true: aktif/muncul/ false: tidak muncul)
        _uiObject?.SetActive(value);
    }
 
    // Function untuk mengubah fill stamina 
    public void SetStaminaFill(float value, float maxValue)
    {
        // Memastikan ada reference ke object image fill 
        if (_staminaFill != null)
        {
            // Mengubah fill amount menjadi value/max value
            // value dibagi max value karena, range nilai
            // fill adalah 0 s.d. 1.  
            _staminaFill.fillAmount = value / maxValue;
        }
    }
}