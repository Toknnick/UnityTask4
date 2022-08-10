using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isEnteredSomeBodyInAlarmZone;

    public void ChangeMode(bool isEnteredSomeBodyInAlarmZone)
    {
        _isEnteredSomeBodyInAlarmZone = isEnteredSomeBodyInAlarmZone;
    }

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (true)
        {
            int targetVolume;

            if (_isEnteredSomeBodyInAlarmZone == true)
                targetVolume = 1;
            else
                targetVolume = 0;

            if (_audioSource.isPlaying == false)
                _audioSource.Play();
            else if (_audioSource.volume <= 0)
                _audioSource.Stop();

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }
    }

}
