using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Réglage du volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    // Changer la résolution
    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    // Activer/Désactiver le plein écran
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // Sauvegarder les préférences
    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }

    // charger les graphismes du jeu
    public void SetGraphicsQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    
}