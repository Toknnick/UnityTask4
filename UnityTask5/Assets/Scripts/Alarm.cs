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

    private void Update()
    {
        int maxVolume = 1;

        if (_isEnteredSomeBodyInAlarmZone == true)
            StartCoroutine(ChangeVolume(maxVolume));
        else
            StartCoroutine(ChangeVolume(0));
    }

    private IEnumerator ChangeVolume(int target)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();
        else if (_audioSource.volume <= 0)
            _audioSource.Stop();

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, Time.deltaTime);
        yield return null;
    }
}
