using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound, _pickedSound;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }
    public void PlayPickedSound()
    {
        _audioSource.PlayOneShot(_pickedSound);
    }
}
