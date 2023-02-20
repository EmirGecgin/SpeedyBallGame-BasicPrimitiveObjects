using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerHorizontalSpeed;
    public Vector3 respawnPoint;
    private GameManager _gameManager;
    public TextMeshProUGUI scoreText;
    public int score=0;
    public AudioSource coinSound;
    public AudioSource crashSound;
    public AudioSource endingSound;
    
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        _gameManager = FindObjectOfType<GameManager>();
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _rb.AddForce(/*moveHorizontal*playerHorizontalSpeed*Time.fixedDeltaTime*/0,0,playerSpeed* Time.fixedDeltaTime);
        _rb.velocity = new Vector3(moveHorizontal * playerHorizontalSpeed, _rb.velocity.y, _rb.velocity.z);
        if (gameObject.transform.position.y <= -5.6f)
        {
            crashSound.Play();
            StopMovement();
            _gameManager.RespawnPlayer();
            

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            crashSound.Play();
            StopMovement();
            _gameManager.RespawnPlayer();
            
        }
    }

    private void StopMovement()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("coin"))
        {
            Score();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("ending"))
        {
            endingSound.Play();
            _gameManager.LevelUp();
            gameObject.SetActive(false);
        }
    }

    private void Score()
    {
        score += 10;
        coinSound.Play();
        scoreText.text = score.ToString();
    }
    
    

    
    
}
