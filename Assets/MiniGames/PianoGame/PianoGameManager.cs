using UnityEngine;

public class PianoGameManager : MonoBehaviour
{
    public AudioClip[] noteSounds; // Ses efektlerini tutacak array
    private AudioSource audioSource; // Ses efektlerini �almak i�in AudioSource
    [SerializeField] private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // E�er GameObject �zerinde AudioSource yoksa ekleyin.
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Ses efekti �alma fonksiyonu, bu fonksiyon butonlar�n OnClick() event'lerine atanacak
    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < noteSounds.Length)
        {
            audioSource.PlayOneShot(noteSounds[soundIndex]);
        }
        animator.SetTrigger("happy");
    }
}
