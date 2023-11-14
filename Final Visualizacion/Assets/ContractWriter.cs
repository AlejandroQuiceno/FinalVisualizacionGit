using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContractWriter : MonoBehaviour
{
    [TextArea(20, 10)]
    public string text;

    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.05f;

    public AudioClip[] keySounds;
    public AudioClip[] spaceSounds;

    private AudioSource audioSource;

    [SerializeField] GameObject Firma;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void StartWriting()
    {
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
        foreach (char letter in text.ToCharArray())
        {
            textMeshPro.text += letter;

            // Play sound based on the typed character
            if (char.IsLetterOrDigit(letter))
            {
                PlayRandomSound(keySounds);
            }
            else if (letter == ' ')
            {
                PlayRandomSound(spaceSounds);
            }

            yield return new WaitForSeconds(typingSpeed);
        }
        Firma.SetActive(true);

    }

    private void PlayRandomSound(AudioClip[] sounds)
    {
        if (sounds.Length > 0)
        {
            int randomIndex = Random.Range(0, sounds.Length);
            audioSource.PlayOneShot(sounds[randomIndex]);
        }
    }
}

