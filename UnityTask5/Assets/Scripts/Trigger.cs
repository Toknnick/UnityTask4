using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _alarmed;

    private void OnTriggerEnter(Collider collider)
    {
        int targetVolume = 1;
        _alarmed?.Invoke(targetVolume);
    }

    private void OnTriggerExit(Collider collider)
    {
        int targetVolume = 0;
        _alarmed?.Invoke(targetVolume);
    }
}
