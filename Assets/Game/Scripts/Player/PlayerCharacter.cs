using UnityEngine;
 
public class PlayerCharacter : MonoBehaviour
{
    // Variable untuk reference ke module PlayerCharacterMovement
    [SerializeField]
    private PlayerCharacterMovement _movement;
    // Variable untuk reference ke module PlayerCharacterStamina
    [SerializeField]
    private PlayerCharacterStamina _stamina;
    // Variable untuk reference ke module InventoryManager
    [SerializeField]
    private InventoryManager _inventory;
    // Property untuk mengakses variable _movement
    public PlayerCharacterMovement Movement => _movement;
    // Property untuk mengakses variable _stamina
    public PlayerCharacterStamina Stamina => _stamina;
    // Property untuk mengakses variable _inventory
    public InventoryManager Inventory => _inventory;
    // Variable untuk reference ke module InteractDetector
    [SerializeField]
    private InteractDetector _interactDetector;
    // Property untuk mengakses variable _interactDetector
    public InteractDetector InteractDetector => _interactDetector;
    [SerializeField]
    private CameraManager _camera;
    // Property untuk mengakses variable _camera
    public CameraManager Camera => _camera;
    public bool IsHiding { get; private set; }
     [SerializeField]
    private InputManager _input;
    // Property untuk mengakses variable _input
    public InputManager Input => _input;
    // Function untuk mengubah status hiding player
    // Variable untuk reference ke module Flashlight
    [SerializeField]
    private Flashlight _flashlight;
    // Property untuk mengakses variable _flashlight
    public Flashlight Flashlight => _flashlight;
    public void SetIsHiding(bool isHiding)
    {
        IsHiding = isHiding;
    }
    private void Awake()
    {
        // Ketika game dijalankan,
        // cursor mouse akan disembunyikan
        Cursor.visible = false;
        // cursor mouse akan dikunci di tengah layar
        Cursor.lockState = CursorLockMode.Locked;
    }
}