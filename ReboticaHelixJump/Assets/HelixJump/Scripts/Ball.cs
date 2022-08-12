using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody _rb;
    public float Jumpforce;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        _rb.velocity = new Vector3(_rb.velocity.x, Jumpforce, _rb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)")
        {

        }
        else if (materialName == "Unsafe (Instance)")
        {
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}

