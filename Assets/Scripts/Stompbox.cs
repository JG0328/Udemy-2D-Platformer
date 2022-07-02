using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible;

    [Range(0, 100)]
    public float changeToDrop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.gameObject.SetActive(false);

            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= changeToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
    }
}
