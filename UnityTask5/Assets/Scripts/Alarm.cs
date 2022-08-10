using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void TurnOn()
    {
        int targetVolume = 1;

        Debug.Log("���");
        
        StartCoroutine(ChangeVolumeSmoothly(targetVolume));
    }

    public void TurnOff()
    {
        int targetVolume = 0;

        Debug.Log("����");

        StartCoroutine(ChangeVolumeSmoothly(targetVolume));
    }

    private IEnumerator ChangeVolumeSmoothly(int targetVolume)
    {
        Debug.Log("� ��������");

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume < targetVolume || _audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume <= 0 && _audioSource.isPlaying == true)
            _audioSource.Stop();

        Debug.Log("����� �� ��������.");
    }
} 
