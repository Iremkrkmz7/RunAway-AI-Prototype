using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(collectEffect != null)
            {
                var effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
                Destroy(effect , 2f);
            }
            LevelGenerator.Instance.CoinCollected();
            Destroy(gameObject);Debug.Log($"SoundManager null mu: {SoundManager.Instance == null}");
            SoundManager.Instance.PlayCoin();
        }
    }
}
