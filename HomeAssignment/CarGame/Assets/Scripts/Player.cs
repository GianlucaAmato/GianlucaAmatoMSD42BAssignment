using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] float movementSpeed = 5f;

    float xMin, xMax;
    float padding = 0.5f;

    void Start()
    {
        BounderiesMovement();
    }

    void Update()
    {
        Movement();
    }

    //Camera bounderies
    private void BounderiesMovement()
    {
        Camera CameraGame = Camera.main;

        xMin = CameraGame.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = CameraGame.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    //The player movement
    private void Movement()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var newXPos = transform.position.x + deltaX;

        var newYPos = transform.position.y;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access DamageDealer from otherObject that hit the enemy
        //and reduce health accordingly
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmg);

    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        dmg.Hit();
        //destroy enemy laser
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
