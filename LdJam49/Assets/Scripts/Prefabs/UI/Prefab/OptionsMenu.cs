
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider EffectsVolumeSlider;
    public Slider AmbienceVolumeSlider;
    public Slider BackgroundVolumeSlider;
    public Toggle AnimationEnabledToggle;

    private void Start()
    {
        this.UpdateValues();
    }

    private void FixedUpdate()
    {
        this.UpdateValues();
    }

    public void OnForegroundSliderChanged()
    {
        Core.EffectsAudioManager.Volume = EffectsVolumeSlider.value;
    }

    public void OnAmbienceSliderChanged()
    {
        Core.AmbienceAudioManager.Volume = AmbienceVolumeSlider.value;
    }

    public void OnBackgroundSliderChanged()
    {
        Core.BackgroundAudioManager.Volume = BackgroundVolumeSlider.value;
    }

    public void OnAnimationEnabledToggleValueChanged()
    {
        Core.Options.AreAnimationsEnabled = this.AnimationEnabledToggle.isOn;
    }

    public void OnRestoreDefaultsClick()
    {
        Core.EffectsAudioManager.Volume = 1f;
        Core.AmbienceAudioManager.Volume = 0.125f;
        Core.BackgroundAudioManager.Volume = 0.125f;
        Core.Options.AreAnimationsEnabled = true;
    }

    private void UpdateValues()
    {
        if (Core.Options != default)
        {
            if (this.EffectsVolumeSlider.value != Core.Options.EffectsVolume)
            {
                this.EffectsVolumeSlider.value = Core.Options.EffectsVolume;
            }

            if (this.AmbienceVolumeSlider.value != Core.Options.AmbienceVolume)
            {
                this.AmbienceVolumeSlider.value = Core.Options.AmbienceVolume;
            }

            if (this.BackgroundVolumeSlider.value != Core.Options.BackgroundVolume)
            {
                this.BackgroundVolumeSlider.value = Core.Options.BackgroundVolume;
            }

            if (this.AnimationEnabledToggle.isOn != Core.Options.AreAnimationsEnabled)
            {
                this.AnimationEnabledToggle.isOn = Core.Options.AreAnimationsEnabled;
            }
        }
    }
}
