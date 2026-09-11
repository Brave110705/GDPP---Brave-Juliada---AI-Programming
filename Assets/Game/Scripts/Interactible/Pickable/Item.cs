using UnityEngine;

public class item : MonoBehaviour, IInteractable, IPickable
{
    [SerializeField]
    private ItemData _itemData;

    public string Name => _itemData.Name;

    public void Interact()
    {
        Pickup();
    }

    public void Pickup()
    {
        throw new System.NotImplementedException();
    }
}