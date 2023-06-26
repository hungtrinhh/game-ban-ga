// Decompiled with JetBrains decompiler
// Type: AudioController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3C06A46-84F4-4FF2-AFD3-9A4450E8BABA
// Assembly location: D:\Project game\game ban ga\Temp\Bin\Debug\Assembly-CSharp\Assembly-CSharp.dll
// Local variable names from D:\Project game\game ban ga\Temp\Bin\Debug\Assembly-CSharp\Assembly-CSharp.pdb

using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] ListSoundChickenDeath;
    [SerializeField] private AudioClip[] ListSoundHurt;
    [Space] [SerializeField] private AudioClip EattingSound;
    [SerializeField] private AudioClip DesTroySound;
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip FireSound;
    [SerializeField] private AudioClip LevelUpSound;


    [Space] private List<AudioSource> ListAudioSource;
    public static AudioController Instan;

    private void Awake()
    {
        if (!((Object)AudioController.Instan == (Object)null))
            return;
        AudioController.Instan = this;
    }


    private void Start()
    {
        this.ListAudioSource = new List<AudioSource>();
        PlayBackgroundMusic();
    }


    public void PlayBackgroundMusic()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.BackgroundMusic;
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = this.BackgroundMusic;
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.BackgroundMusic;
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlayLevelUpSound()
    {

        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.LevelUpSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }

        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = this.LevelUpSound;
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.LevelUpSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlayFireSound()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.FireSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = this.FireSound;
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.FireSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlayChickenHurt()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.ListSoundHurt[Random.Range(0, this.ListSoundHurt.Length - 1)];
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = this.ListSoundHurt[Random.Range(0, this.ListSoundHurt.Length - 1)];
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.ListSoundHurt[Random.Range(0, this.ListSoundHurt.Length - 1)];
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlayChickenDeath()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.ListSoundChickenDeath[Random.Range(0, this.ListSoundChickenDeath.Length - 1)];
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip =
                        this.ListSoundChickenDeath[Random.Range(0, this.ListSoundChickenDeath.Length - 1)];
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.ListSoundChickenDeath[Random.Range(0, this.ListSoundChickenDeath.Length - 1)];
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlaySoundPlayerDeath()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.DesTroySound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip =
                        this.DesTroySound;
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.DesTroySound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }

    public void PlayPlayreEat()
    {
        if (this.ListAudioSource.Count == 0)
        {
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.EattingSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
        else
        {
            foreach (AudioSource audioSource in this.ListAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = this.EattingSound;
                    audioSource.Play();
                    return;
                }
            }

            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = this.EattingSound;
            a.Play();
            this.ListAudioSource.Add(a);
        }
    }
}