using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audio;

    private bool _isEntered;

    private void Update()
    {
        float maxVolume = 1;
        float soundSpeedIncrease = 0.09f;

        if (_isEntered == true)
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.PlayOneShot(_audio);
            }

            if (_audioSource.volume < maxVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxVolume,Time.deltaTime * soundSpeedIncrease);
            }
        }
        else if (_isEntered == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * soundSpeedIncrease);

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        _isEntered = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        _isEntered = false;
    }
}
