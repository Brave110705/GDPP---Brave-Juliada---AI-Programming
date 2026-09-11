using UnityEngine; 
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction; 
public class InputManager : MonoBehaviour, IPlayerActions
{ 
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent<bool> OnSprintInput;
    // Variable untuk menyimpan reference object input action 
    private GameInputAction _inputAction; 
    private void Awake() 
    { 
        // Membuat object GameInputAction dan menyimpan reference nya 
        // ke variable _inputAction 
        _inputAction = new GameInputAction(); 
        // Mengaktifkan input action 
        _inputAction.Enable(); 
        // Mengaktifkan action map Player 
        _inputAction.Player.Enable(); 
        // Memberi tahu bahwa kelas ini akan mendeteksi input dari 
        // action map Player 
        _inputAction.Player.SetCallbacks(this); 
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact"); 
    } 
    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed) 
        { 
            OnSprintInput?.Invoke(true); 
        } 
        if (context.canceled) 
        { 
            OnSprintInput?.Invoke(false); 
        }         
    }
} 