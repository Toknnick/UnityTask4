using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _activated;

    private void OnTriggerEnter(Collider collider)
    {
        int numberOfEvent = 0;
        _activated[numberOfEvent].Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        int numberOfEvent = 1;
        _activated[numberOfEvent].Invoke();
    }
}
