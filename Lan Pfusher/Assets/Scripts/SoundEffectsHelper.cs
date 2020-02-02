using UnityEngine;
using System.Collections;

/// <summary>
/// Création d'effets sonores en toute simplicité
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundEffectsHelper : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static SoundEffectsHelper Instance;

    public AudioClip SoundEffect_Non;
    public AudioClip SoundEffect_ChangementObjet;
    public AudioClip SoundEffect_ValiderTouche;
    public AudioClip SoundEffect_ChangementTouche;
    public AudioClip SoundEffect_Enervement;
    public AudioClip SoundEffect_Escalier;
    public AudioClip SoundEffect_Esouflement;
    public AudioClip SoundEffect_JeterObjet;
    public AudioClip SoundEffect_MarcheRapide;
    public AudioClip SoundEffect_MarcheRapideFin;
    public AudioClip SoundEffect_Oh;
    public AudioClip SoundEffect_PanneCable;
    public AudioClip SoundEffect_PanneCasque;
    public AudioClip SoundEffect_PanneClavier;
    public AudioClip SoundEffect_PanneSouris;
    public AudioClip SoundEffect_PanneTour;
    public AudioClip SoundEffect_PrendreMur;
    public AudioClip SoundEffect_PrendreObjet;
    public AudioClip SoundEffect_Reparation;
    public AudioClip SoundEffect_ReparationFini;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeSoundEffect(AudioClip SoundEffect)
    {
        MakeSound(SoundEffect);
    }

    /// <summary>
    /// Lance la lecture d'un son
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}