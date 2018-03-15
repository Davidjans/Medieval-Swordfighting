using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicVolume : MonoBehaviour {
    [SerializeField] private Slider m_MusicVolume;

    public void Update()
    {
        AudioListener.volume = m_MusicVolume.value;
    }
}
