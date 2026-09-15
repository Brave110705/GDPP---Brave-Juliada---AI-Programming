using UnityEngine;
 
public class DisplayCursor : MonoBehaviour
{
    // Function untuk memunculkan cursor
    public void ShowCursor()
    {
        // Memunculkan cursor
        Cursor.visible = true;
        // Membuat cursor tidak terkunci di tengah layar
        Cursor.lockState = CursorLockMode.None;
    }
}