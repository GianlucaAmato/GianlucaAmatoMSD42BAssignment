using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] float BulletTimer;
    [SerializeField] float MinimumBulletTime = 0.2f;
    [SerializeField] float MaximumBulletTime = 3f;
    [SerializeField] float BulletSpeed = 5f;
    [SerializeField] GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        BulletTimer = Random.Range(MinimumBulletTime, MaximumBulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        ShootTimer();
    }

    private void ShootTimer()
    {
        //reduce time every frame
        BulletTimer -= Time.deltaTime;

        if (BulletTimer <= 0f)
        {
            //enemy shoots
            EnemyFire();
            //reset shotCounter timer
            BulletTimer = Random.Range(MinimumBulletTime, MaximumBulletTime);
        }
    }

    private void EnemyFire()
    {
        GameObject CannonBall = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //give the laser a velocity in the y-axis
        CannonBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -BulletSpeed);
    }
}
