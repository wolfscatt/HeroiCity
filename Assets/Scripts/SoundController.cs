using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider soundSlider;
    public Toggle soundToggle;
    public AudioSource audioSource;

    void Start()
    {
        // Başlangıçta ses kaydırıcısının değerini varsayılan ses seviyesine ayarlayın
        soundSlider.value = audioSource.volume;
        audioSource.mute = !soundToggle.isOn;
    }

    // Slider'ın değeri değiştiğinde çağrılacak fonksiyon
    public void ChangeVolume(float volume)
    {
        // Slider'ın değeri, ses seviyesini temsil eder. Ses seviyesini güncelleyin.
        audioSource.volume = volume;
    }

    public void ToggleSound()
    {
        // Toggle'ın değerine göre sesi açma veya kapatma
        audioSource.mute = !soundToggle.isOn;
    }
}
