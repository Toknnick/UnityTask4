using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _activated;

    private void OnTriggerEnter(Collider collider)
    {
        _activated?.Invoke(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        _activated?.Invoke(false);
    }
}
