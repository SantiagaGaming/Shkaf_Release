using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePlayer : MonoBehaviour
{
    [SerializeField]private AudioClip _startOpenDoorVoice, _upLocekerVoice,_downLockerVoice, _midLockerVoice, _magnetVoice,_openDoorVoice, _doorIsOpenVoice,
        _pickobjectsDoorVoice, _wrongItemVoice, _klemmVoice, _pickObjectsVoice,_klemmPowerVoice, _batteryPowerVoice, _batteryPowerOnVoice,
        _goToplateVoice,_connectOscilVoice, _oscilPlateConnectVoice, _blackWireConnectVoice,_redWireConnectVoice, _wiresConnectedDoneVoice,_upDoorWalkVoice,
        _circleKeyOpenDoorVoice;
    private AudioSource _audioSource;
   
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void StopAudioSource()
    {
        _audioSource.Stop();
    }
    public void PlayStartOpenDoorVoice()
    {
        _audioSource.PlayOneShot(_startOpenDoorVoice);
    }

    public void PlayUpLockerVoice()
    {
        _audioSource.PlayOneShot(_upLocekerVoice);
    }
    public void PlayDownLockerVoice()
    {
        _audioSource.PlayOneShot(_downLockerVoice);
    }
    public void PlayMidLockerVoice()
    {
        _audioSource.PlayOneShot(_midLockerVoice);
    }
    public void PlayMagnetVoice()
    {
        _audioSource.PlayOneShot(_magnetVoice);
    }
    public void PlayOpenDoorVoice()
    {
        _audioSource.PlayOneShot(_openDoorVoice);
    }
    public void PlayDoorIsOpenVoice()
    {
        _audioSource.PlayOneShot(_doorIsOpenVoice);
    }
    public void PlayPickObjectsForDoorVoice()
    {
        _audioSource.PlayOneShot(_pickobjectsDoorVoice);
    }
    public void PlayWrongItemVoice()
    {
        _audioSource.PlayOneShot(_wrongItemVoice);
    }
    public void PlayKlemmVoice()
    {
        _audioSource.PlayOneShot(_klemmVoice);
    }
    public void PlayPickObjectsVoice()
    {
        _audioSource.PlayOneShot(_pickObjectsVoice);
    }
    public void PlayKlemPowerVoice()
    {
        _audioSource.PlayOneShot(_klemmPowerVoice);
    }
    public void PlayBatteryPowerVoice()
    {
        _audioSource.PlayOneShot(_batteryPowerVoice);
    }
    public void PlayBatteryPowerOnVoice()
    {
        _audioSource.PlayOneShot(_batteryPowerOnVoice);
    }
    public void PlayGoToPlateVoice()
    {
        _audioSource.PlayOneShot(_goToplateVoice);
    }
    public void PlayConnectOscilVoice()
    {
        _audioSource.PlayOneShot(_connectOscilVoice);
    }
    public void PlayOscilPlateConnectVoice()
    {
        _audioSource.PlayOneShot(_oscilPlateConnectVoice);
    }
    public void PlayBlackWireConnectVoice()
    {
        _audioSource.PlayOneShot(_blackWireConnectVoice);
    }
    public void PlayRedWireConnectVoice()
    {
        _audioSource.PlayOneShot(_redWireConnectVoice);
    }
    public void PlayWireConnectedDoneVoice()
    {
        _audioSource.PlayOneShot(_wiresConnectedDoneVoice);
    }
    public void PlayUpDoorWalkVoice()
    {
        _audioSource.PlayOneShot(_upDoorWalkVoice);
    }
    public void PlayCircleKeyOpenDoorVoice()
    {
        _audioSource.PlayOneShot(_circleKeyOpenDoorVoice);
    }


}
