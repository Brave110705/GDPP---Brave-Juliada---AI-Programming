using UnityEngine;
using UnityEngine.UI;
 
public class CrosshairUI : MonoBehaviour
{
    // Variable untuk menentukan color
    // dari image crosshair, ketika tidak
    // mendeteksi interactable object
    [SerializeField]
    private Color _normalColor = Color.white;
    // Variable untuk menentukan color
    // dari image crosshair, ketika
    // mendeteksi interactable object
    [SerializeField]
    private Color _highlightColor = Color.white;
    // Variable untuk reference ke 
    // component Image dari object UI Crosshair
    [SerializeField]
    private Image _crosshairImage;
 
    private void Awake()
    {
        // Ketika game dimulai set crosshair untuk
        // tidak mendeteksi object interactable
        SetHighlight(false);
    }
 
    // Function apakah cursor berubah warna 
    // menjadi highlight color atau normal color
    // melalui parameter (true: highlight color,
    // false: normal color)
    public void SetHighlight(bool value)
    {
        if (value == true)
        {
            // JIka mendeteksi object interactable
            // ubah warna crosshair menjadi highlight color
            _crosshairImage.color = _highlightColor;
        }
        else
        {
            // JIka tidak mendeteksi object interactable
            // ubah warna crosshair menjadi normal color
            _crosshairImage.color = _normalColor;
        }
    }
}