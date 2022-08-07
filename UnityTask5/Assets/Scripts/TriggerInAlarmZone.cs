using UnityEngine;

public class TriggerInAlarmZone : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider collider)
    {
        _alarm.TurnOff();
    }
}
