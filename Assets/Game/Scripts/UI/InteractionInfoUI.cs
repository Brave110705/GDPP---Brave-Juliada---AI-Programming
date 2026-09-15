using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class InteractionInfoUI : MonoBehaviour
{
    // Variable untuk reference object UI InteractionInfo
    [SerializeField]
    private GameObject _uiObject;
    // Variable untuk reference component 
    // text dari nama object
    [SerializeField]
    private TMP_Text _nameText;
 
    // Function untuk memunculkan dan 
    // menyembunyikan object UI InteractionInfo
    public void SetVisible(bool value)
    {
        // Mengubah status active berdasarkan 
        // parameter function (true: aktif/muncul/ false: tidak muncul)
        _uiObject?.SetActive(value);
    }
 
    // Function untuk mengubah text nama object
    public void SetNameText(string text)
    {
        // Mengubah text dari nama object sesuai dengan
        // nama yang ada di parameter text
        _nameText.text = text;
        // Mengupdate canvas jika ada nama yang panjang
        Canvas.ForceUpdateCanvases();
        // Mengupdate vertical layout jika ada nama yang panjang
        LayoutRebuilder.ForceRebuildLayoutImmediate(_uiObject.GetComponent<RectTransform>());
        // Mengupdate canvas setelah vertical layout terupdate
        Canvas.ForceUpdateCanvases();
    }
}