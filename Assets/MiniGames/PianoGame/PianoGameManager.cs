using UnityEngine;

public class PianoGameManager : MonoBehaviour
{
    public AudioClip[] noteSounds; // Ses efektlerini tutacak array
    private AudioSource audioSource; // Ses efektlerini çalmak için AudioSource
    [SerializeField] private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // Eðer GameObject üzerinde AudioSource yoksa ekleyin.
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Ses efekti çalma fonksiyonu, bu fonksiyon butonlarýn OnClick() event'lerine atanacak
    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < noteSounds.Length)
        {
            audioSource.PlayOneShot(noteSounds[soundIndex]);
        }
        animator.SetTrigger("happy");
    }
}
