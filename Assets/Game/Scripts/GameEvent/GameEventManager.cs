using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; private set; }

    private Dictionary<string, GameEventBase> _gameEvents = new Dictionary<string, GameEventBase>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void Register(GameEventBase gameEvent)
    {
        if (gameEvent == null || string.IsNullOrEmpty(gameEvent.ID)) return;

        if (!_gameEvents.ContainsKey(gameEvent.ID))
        {
            _gameEvents.Add(gameEvent.ID, gameEvent);
        }
    }

    public void Unregister(GameEventBase gameEvent)
    {
        if (gameEvent == null || string.IsNullOrEmpty(gameEvent.ID)) return;

        if (_gameEvents.ContainsKey(gameEvent.ID))
        {
            _gameEvents.Remove(gameEvent.ID);
        }
    }

    public void TriggerEvent(string id)
    {
        if (string.IsNullOrEmpty(id)) return;

        if (_gameEvents.TryGetValue(id, out GameEventBase gameEvent))
        {
            gameEvent?.Trigger();
        }
        else
        {
            Debug.LogWarning($"[GameEventManager] Event '{id}' was triggered but is not registered.");
        }
    }

    public void FinishEvent(string id)
    {
        if (string.IsNullOrEmpty(id)) return;

        if (_gameEvents.TryGetValue(id, out GameEventBase gameEvent))
        {
            gameEvent?.Finish();
        }
    }
}