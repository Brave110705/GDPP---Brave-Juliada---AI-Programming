using UnityEngine;
using UnityEngine.Events;
public class Door : MonoBehaviour, IInteractable
{
    // Variable untuk reference ke component transform pintu.
    // Component transform digunakan untuk menggeser posisi dan memutar pintu
    [SerializeField]
    protected Transform _doorTransform;
    // Variable untuk menentukan durasi animasi membuka dan menutup pintu
    [SerializeField]
    protected float _duration = 1f;
    // Variable untuk menentukan apakah pintu dikunci atau tidak
    [SerializeField]
    protected bool _isLocked;
    // Variable untuk menentukan id kunci untuk membuka pintu
    [SerializeField]
    protected string _keyID;
    // Variable untuk menentukan apakah pintu sedang dianimasikan untuk terbuka
    // dan tertutup
    protected bool _isAnimating;
 
    // Variable untuk menentukan apakah pintu sedang terbuka atau tertutup
    protected bool _isOpen;
    // Property untuk mendapatkan variable _isAnimating
    public bool IsAnimating => _isAnimating;

    [SerializeField]
    private string _name;
    // Wajib membuat property Name
    // Property Name diisikan nilai variable _name
    public string Name => _name;

    // Membuat event yang akan dipanggil ketika pintu terbuka
    public UnityEvent OnDoorOpen;
    // Membuat event yang akan dipanggil ketika pintu tertutup
    public UnityEvent OnDoorClose;
    protected Coroutine _animatingDoorCoroutine;
    [ContextMenu("Interact Door")]
    public void test_interact()
    {
        if (_isOpen == true)
        {
            // Jika pintu terbuka maka tutup pintu
            Close();
        }
        else
        {
            // Jika pintu tertutup maka buka pintu
            Open();
        }       
    }
    public void Interact(PlayerCharacter character)
    {
        // Mengecek apakah pintu dikunci
        if (_isLocked == true)
        {
            // Jika pintu dikunci
            // Mengecek apakah player memiliki kuncinya di inventory 
            // dengan menggunakan ID nya
            bool hasKey = character.Inventory.CheckItem(_keyID);
            if (hasKey == true)
            {
                // Jika punya maka mengubah status pintu menajdi tidak terkunci
                _isLocked = false;
                // Kemudian buka pintu
                Open();
            }
        }
        else
        {
            // Jika tidak terkunci atau kunci telah dibuka
            // Mengecek apakah pintu sedang terbuka
            if (_isOpen == true)
            {
                // Jika pintu terbuka maka tutup pintu
                Close();
            }
            else
            {
                // Jika pintu tertutup maka buka pintu
                Open();
            }
        }
    }
 
    // Function untuk membuka pintu
    public virtual void Open()
    {
        // Mengubah status pintu menjadi terbuka
        _isOpen = true;
        // Memanggil event untuk memberitahu class lain bahwa pintu telah dibuka
        OnDoorOpen?.Invoke();
    }
 
    // Function untuk menutup pintu
    public virtual void Close()
    {
        // Mengubah status pintu menjadi tertutup
        _isOpen = false;
        // Memanggil event untuk memberitahu class lain bahwa pintu telah ditutup
        OnDoorClose?.Invoke();
    }
}