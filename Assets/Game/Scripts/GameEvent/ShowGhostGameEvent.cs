using UnityEngine;

public class ShowGhostGameEvent : GameEventBase
{
    [SerializeField]
    private GameObject _ghostObject;
    [SerializeField]
    private bool _isDestroyAfterFinished;
    [SerializeField]

    private bool _hasBeenTriggered;

    public override void Trigger()
    {
        if (_hasBeenTriggered) return;

        if (_ghostObject != null)
        {
            _hasBeenTriggered = true;
            _ghostObject.SetActive(true);
        }

        base.Trigger();
    }

    public override void Finish()
    {
        if (_ghostObject != null && _isDestroyAfterFinished)
        {
            Destroy(_ghostObject);
        }
        base.Finish();
    }
}