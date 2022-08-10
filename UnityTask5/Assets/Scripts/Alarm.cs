using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void ChangeVolume(bool isActivated)
    {
        int targetVolume;

        if (isActivated)
             targetVolume = 1;
        else
             targetVolume = 0; 

        StartCoroutine(ChangeVolumeSmoothly(targetVolume));
    }

    private void Update()
    {
        int maxVolume = 1;

        if (_audioSource.isPlaying == false && _audioSource.volume >= maxVolume)
            _audioSource.Play();
    }

    private IEnumerator ChangeVolumeSmoothly(int targetVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume < targetVolume || _audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume <= 0 && _audioSource.isPlaying == true)
            _audioSource.Stop();
    }
} 
