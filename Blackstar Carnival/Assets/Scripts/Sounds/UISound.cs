using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonClick;
    
    public void PlayButtonClick()
    {
        SoundManager.Instance.PlaySFX(_buttonClick);
    }
}
