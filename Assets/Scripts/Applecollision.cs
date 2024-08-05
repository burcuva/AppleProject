using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    public GameObject explosionEffect; // Patlama efektinin prefab referansı
    public int TargetValue = 100;
     AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // Skoru güncelle
            Score.instance.score += TargetValue;
            Score.instance.UpdateScore();

            // Patlama efektini oluştur
            Instantiate(explosionEffect, transform.position, transform.rotation);
            audioSource.Play();

            // Elmayı yok et
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Apple"))
        {
            audioSource.Play();
        }
    }
}
