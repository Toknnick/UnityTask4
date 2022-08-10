using UnityEngine;
using UnityEngine.Events;

public class TriggerInAlarmZone : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        _alarm?.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        _alarm?.Invoke(false);
    }
}
