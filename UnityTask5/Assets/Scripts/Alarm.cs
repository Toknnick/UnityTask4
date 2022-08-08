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
        float soundSpeedIncrease = 0.4f;
        int maxSound = 1;
        IEnumerator addSound = ChangeSound(soundSpeedIncrease, maxSound, maxSound);
        IEnumerator turnDownSound = ChangeSound(soundSpeedIncrease, 0, maxSound);
        //IEnumerator coroutine = StartCorout();
        Debug.Log("isPlaying = " + _audioSource.isPlaying);
        Debug.Log("_isEntered = " + _isEntered);

        if (_isEntered == true && _audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
        else if (_isEntered == true && _audioSource.isPlaying == true)
        {
            StartCoroutine(addSound);
        }
        else if(_audioSource.volume > 0 && _audioSource.isPlaying == true && _isEntered == false)
        {
            StopCoroutine(addSound);
            StartCoroutine(turnDownSound);
        }
        else
        {
            StopCoroutine(turnDownSound);
            _audioSource.Stop();
        }
    }

    private IEnumerator ChangeSound(float soundSpeedIncrease, int targetSound, int maxSound)
    {
        if (_audioSource.volume >= 0 && _audioSource.volume <= maxSound)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetSound, Time.deltaTime * soundSpeedIncrease);
            yield return null;
        }
    }
}
