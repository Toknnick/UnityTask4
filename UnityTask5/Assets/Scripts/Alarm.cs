using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isEnteredSomeBodyInAlarmZone;

    public void TurnOn()
    {
        _isEnteredSomeBodyInAlarmZone = true;
    }

    public void TurnOff()
    {
        _isEnteredSomeBodyInAlarmZone = false;
    }

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (true)
        {
            int target;

            if (_isEnteredSomeBodyInAlarmZone == true)
                target = 1;
            else
                target = 0;

            if (_audioSource.isPlaying == false)
                _audioSource.Play();
            else if (_audioSource.volume <= 0)
                _audioSource.Stop();

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, Time.deltaTime);
            yield return null;
        }
    }
}
