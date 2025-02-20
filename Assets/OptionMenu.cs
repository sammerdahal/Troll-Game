using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; // Correct namespace for UI elements like Slider

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer; // Reference to the AudioMixer
    [SerializeField] private Slider musicSlider; // Reference to the UI slider for music volume

    public void SetMusicVolume()
    {
        float volume = musicSlider.value; // Fixed missing '=' for assignment
        myMixer.SetFloat("volume", volume);
    }
}
