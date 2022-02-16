using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickableController : MonoBehaviour
{
    public UnityAction ItemPickedEvent;

    [SerializeField] private Item[] _pickableObjects;
    [SerializeField] private PlayerCanvasViev _playerCanvasViev;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private SoundPlayer _soundPlayer;

    private void Start()
    {
        foreach (var pickable in _pickableObjects)
        {
            pickable.SetHoverNameEvent += OnSetPickableVievText;
            pickable.AddItemEvent += OnAddItemToInvent;
            pickable.WrongItemEvent += OnWrongItemClick;
        }
    }
    private void OnSetPickableVievText(string text)
    {
        if(text=="")
        {
            _playerCanvasViev.EnablePickablePanel(false);
        }
        else
        {
            _playerCanvasViev.EnablePickablePanel(true);
            _playerCanvasViev.ShowPickableText(text);
        }
    }
    private void OnAddItemToInvent(Item item)
    {
        _soundPlayer.PlayPickedSound();
        _playerInventory.AddItem(item);
        _playerCanvasViev.EnablePickablePanel(false);
        ItemPickedEvent?.Invoke();
    }
    private void OnWrongItemClick()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayWrongItemVoice();
    }
}
