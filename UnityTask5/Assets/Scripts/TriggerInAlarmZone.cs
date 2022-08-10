using UnityEngine;
using UnityEngine.Events;

public class TriggerInAlarmZone : MonoBehaviour
{
    [SerializeField] private EventBool _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        _alarm?.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        _alarm?.Invoke(false);
    }
}

[System.Serializable] public class EventBool : UnityEvent<bool> { }
