using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    public Rigidbody shell;
    public Transform fireTransform;
    public float launchForce = 15f;

    private float reloadTimer;
    private PlayerStats stats;
    private TankHealth health;

    private void Start()
    {
        reloadTimer = 0f;
        stats = GetComponent<PlayerStats>();
        health = GetComponent<TankHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireShell();
        }
    }

    private void FireShell()
    {
        if (reloadTimer > stats.reloadSpeed && !health.IsDead())
        {
            Debug.Log("Tried firing a shell");

            // Instantiate and launch the shell.
            reloadTimer = 0;

            // Create instance of shell and store reference to its rigidBody
            Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;

            // Set the shells velocity to the launch force in the fires position forward direction
            shellInstance.velocity = launchForce * fireTransform.forward;
        }
    }
}
