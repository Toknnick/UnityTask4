using System.Collections;
using UnityEngine;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    public void MixSound()
    {
        float soundSpeedIncrease = 0.4f;
        int maxSound = 1;
        IEnumerator addSound = ChangeSound(soundSpeedIncrease, maxSound, maxSound);
        IEnumerator turnDownSound = ChangeSound(soundSpeedIncrease, 0, maxSound);

        if (_alarm.IsEntered == true && _alarm.AudioSource.isPlaying == false)
        {
            _alarm.AudioSource.Play();
        }
        else if (_alarm.IsEntered == true && _alarm.AudioSource.isPlaying == true)
        {
            StartCoroutine(addSound);
        }
        else if (_alarm.AudioSource.volume > 0 && _alarm.AudioSource.isPlaying == true && _alarm.IsEntered == false)
        {
            StopCoroutine(addSound);
            StartCoroutine(turnDownSound);
        }
        else
        {
            StopCoroutine(turnDownSound);
            _alarm.AudioSource.Stop();
        }
    }

    private IEnumerator ChangeSound(float soundSpeedIncrease, int targetSound, int maxSound)
    {
        if (_alarm.AudioSource.volume >= 0 && _alarm.AudioSource.volume <= maxSound)
        {
            _alarm.AudioSource.volume = Mathf.MoveTowards(_alarm.AudioSource.volume, targetSound, Time.deltaTime * soundSpeedIncrease);
            yield return null;
        }
    }
}
