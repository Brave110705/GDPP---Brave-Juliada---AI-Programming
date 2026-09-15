using System.Collections;
using UnityEngine;
 
public class PlayerCharacterStamina : MonoBehaviour
{
    // Membuat variable untuk reference 
    // ke object module PlayerCharacterMovement
    [SerializeField]
    private PlayerCharacterMovement _characterMovement;
    // Membuat variable untuk menentukan maksimum stamina player
    [SerializeField]
    private float _maxStamina = 100;
    // Membuat variable untuk menentukan 
    // jumlah stamina yang dibutuhkan untuk sprint
    [SerializeField]
    private float _sprintStaminaCost = 20;
    // Membuat variable untuk menentukan nilai regenerasi stamina
    [SerializeField]
    private float _staminaRegenValue = 20;
 
    // Membuat menghitung stamina yang dimiliki player character
    private float _currentStamina;
    // Variable untuk menyimpan coroutine 
    // menunggu StaminaUI dinonaktifkan
    private Coroutine _stopRegenStaminaCoroutine;
    // Variable untuk menyimpan status apakah 
    // sedang menunggu StaminaUI dinonaktifkan
    private bool _isWaitingRegenStamina;
    [SerializeField]
    private AudioSource _breathingAudio;
    private void Awake()
    {
        // Di awal gae stamina player diset menjadi maksimum
        _currentStamina = _maxStamina;
    }
 
    private void Update()
    {
        // Menghitung stamina terus menerus sepanjang game
        CalculateStamina();
    }

    private void Start()
    {
        // Di awal game stamina player diset menjadi maksimum
        _currentStamina = _maxStamina;
        // Mengupdate stamina bar sesuai dengan jumlah stamina player
        HUDManager.Instance.StaminaUI.SetStaminaFill(_currentStamina, _maxStamina);
    }
    public void CalculateStamina()
    {
        // Jika sedang sprint,
        // Mengecek apakah character sedang sprint atau tidak
        if (_characterMovement.IsSprint)
        {
            // Jika coroutine untuk menunggu menonaktifkan object StaminaUI
            // sedang berjalan, maka hentikan coroutine
            if (_stopRegenStaminaCoroutine != null)
            {
                StopCoroutine(_stopRegenStaminaCoroutine);
                _stopRegenStaminaCoroutine = null;
            }
            // Mengubah status tidak sedang
            // menunggu menonaktifkan object StaminaUI
            _isWaitingRegenStamina = false;
 
            // Mengecek apakah stamina masih ada
            if (_currentStamina > 0)
            {
                // Jika sedang sprint dan stamina masih ada
                // stamina akan dikurangi dengan jumlah stamina yang dibutuhkan.
                // Dikalikan dengan Time.deltaTime karena 
                // function ini akan dipanggil oleh function Update.
                _currentStamina = _currentStamina - 
                                  _sprintStaminaCost * Time.deltaTime;
            }
            else
            {
                // Jika sedang sprint dan stamina habis, 
                // maka player berhenti sprint.
                _characterMovement.SetSprint(false);
            }
        }
        else
        {
            // Jika character tidak sedang sprint, dan stamina belum penuh 
            if (_currentStamina < _maxStamina)
            {
                // maka tambahkan stamina dengan
                // nilai regenerasi stamina.
                // Dikalikan dengan Time.deltaTime karena 
                // function ini akan dipanggil oleh function Update.
                _currentStamina = _currentStamina + 
                                  _staminaRegenValue * Time.deltaTime;
            }
            else if (_isWaitingRegenStamina == false)
            {
                // Jika stamina sudah penuh dan 
                // tidak sedang menunggu menonaktifkan object StaminaUI
                // Menjalankan coroutine StopRegenStaminaWait
                _stopRegenStaminaCoroutine = StartCoroutine(StopRegenStaminaWait());
                // Mengubah status menjadi sedang
                // menunggu menonaktifkan object StaminaUI
                _isWaitingRegenStamina = true;
            }
        }
        // Membatasi stamina player, minimum: 0; maksimum: maximum stamina 
        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina);
        _breathingAudio.volume = 1 - (_currentStamina / _maxStamina);
        HUDManager.Instance.StaminaUI.SetStaminaFill(_currentStamina, _maxStamina);
    }
 
    private IEnumerator StopRegenStaminaWait()
    {
        // Menunggu 1 detik sebelum stamina UI disembunyika kembali
        yield return new WaitForSeconds(1f);
        // Menyembunyikan object Stamina UI
        HUDManager.Instance.StaminaUI.SetVisible(false);
    }
}