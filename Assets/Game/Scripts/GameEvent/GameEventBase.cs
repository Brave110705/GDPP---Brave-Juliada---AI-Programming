using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventBase : MonoBehaviour
{
    [SerializeField]
    private string _id;
    public string ID => _id;

    [SerializeField]
    private bool _isOneTime;

    public UnityEvent OnEventTriggered;
    public UnityEvent OnEventFinished;
    public void Start()
    {
        //return;
        //register event here
        GameEventManager.Instance.Register(this);
    }
    public virtual void Trigger()
    {
        OnEventTriggered?.Invoke();
    }

    public virtual void Finish()
    {
        OnEventFinished?.Invoke();
        if (_isOneTime == true)
        {
            GameEventManager.Instance.Unregister(this);
            Destroy(gameObject);
        }
    }
}