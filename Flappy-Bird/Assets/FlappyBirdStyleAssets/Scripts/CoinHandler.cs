using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour
{
    public GameObject coin;
    public AudioClip coinsound;

    void OnTriggerEnter2D(Collider2D other)
    {

        GameControl.instance.BirdScored();
        AudioSource.PlayClipAtPoint(coinsound, other.transform.position);
        Destroy(coin);

    }
}