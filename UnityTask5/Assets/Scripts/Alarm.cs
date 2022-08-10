using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void ChangeVolume(int targetVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        StartCoroutine(ChangeVolumeSmoothly(targetVolume));

        if (_audioSource.volume <= 0 && _audioSource.isPlaying == true)
            _audioSource.Stop();
    }

    private void Update()
    {
        int maxVolume = 1;

        if (_audioSource.isPlaying == false && _audioSource.volume >= maxVolume)
            _audioSource.Play();
    }
    private IEnumerator ChangeVolumeSmoothly(int targetVolume)
    {
        while (_audioSource.volume < targetVolume || _audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }
    }
} 
