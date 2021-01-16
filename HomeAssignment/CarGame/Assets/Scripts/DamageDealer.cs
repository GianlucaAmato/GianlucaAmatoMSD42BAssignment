using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [SerializeField] public bool IsEnemy = false;

    [SerializeField] GameObject DeathEffect;
    [SerializeField] float explosionDuration = 0.5f;

    [SerializeField] AudioClip ObstacleDeathSound;
    [SerializeField] [Range(0, 1)] float obstacleDeathSoundVolume;

    

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (IsEnemy == true)
        {
            Die();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        //destroy enemy
        Destroy(gameObject);
        GameObject explosion = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, obstacleDeathSoundVolume);

        Destroy(explosion, explosionDuration);

    }
}
