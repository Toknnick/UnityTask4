using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isEntered;

    public void TurnOn()
    {
        _isEntered = true;
    }

    public void TurnOff()
    {
        _isEntered = false;
    }

    private void Update()
    {
        ChangeSound();
    }

    private void ChangeSound()
    {
        float soundSpeedIncrease = 0.4f;

        if (_isEntered == true)
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            StopCoroutine(TurnDownSound(soundSpeedIncrease));
            StartCoroutine(AddSound(soundSpeedIncrease));
        }
        else if (_isEntered == false)
        {
            StopCoroutine(AddSound(soundSpeedIncrease));
            StartCoroutine(TurnDownSound(soundSpeedIncrease));

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }
        }
    }

    private IEnumerator AddSound(float soundSpeedIncrease)
    {
        float maxSound = 1;

        if (_audioSource.volume < maxSound)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxSound, Time.deltaTime * soundSpeedIncrease);
            yield return null;
        }
    }

    private IEnumerator TurnDownSound(float soundSpeedIncrease)
    {
        if (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * soundSpeedIncrease);
            yield return null;
        }
    }
}
