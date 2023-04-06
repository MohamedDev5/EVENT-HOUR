using UnityEngine;
using System.Collections;

public class CoCoins : MonoBehaviour {
    public GameObject objectToHide;
    public GameObject objectToShow;
    public AudioClip soundToPlay;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            objectToHide.SetActive(false);
            objectToShow.SetActive(true);
            AudioSource.PlayClipAtPoint(soundToPlay, transform.position);
        }
    }
}