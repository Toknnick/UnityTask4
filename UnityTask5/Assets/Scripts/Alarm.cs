using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [SerializeField] private UnityEvent _audioMixer;

    public bool IsEntered { get; private set; }

    public void TurnOn()
    {
        IsEntered = true;
    }

    public void TurnOff()
    {
        IsEntered = false;
    }

    private void Update()
    {
        _audioMixer.Invoke();
    }
}
