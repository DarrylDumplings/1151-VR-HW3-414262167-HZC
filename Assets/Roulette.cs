using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Roulette : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    public AudioClip clickSound;
    public float stepAngle = 45f;

    float rotSpeed = 0;
    int lastStep;

    void Start()
    {
        Application.targetFrameRate = 60;
        lastStep = Mathf.FloorToInt(transform.eulerAngles.z / stepAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            this.rotSpeed = 24;
        }
        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.985f;

        int currentStep = Mathf.FloorToInt(transform.eulerAngles.z / stepAngle);
        if (currentStep != lastStep)
        {
            audioSource.PlayOneShot(clickSound);
            lastStep = currentStep;
        }
    }
}
