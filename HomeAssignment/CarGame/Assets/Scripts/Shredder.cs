using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        print(otherObject.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer DD = otherObject.gameObject.GetComponent<DamageDealer>();

        ShredderInteract(DD);
    }

    private void ShredderInteract(DamageDealer DD)
    {
        if (DD.IsEnemy == true)
        {
            Destroy(DD.gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
        else
        {
            Destroy(DD.gameObject);
        }
    }
}
