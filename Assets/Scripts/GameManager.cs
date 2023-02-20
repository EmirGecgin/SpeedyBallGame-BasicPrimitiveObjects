using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public PlayerController _playerController;
    [SerializeField]private float waitSecond = 2f;
    private bool _isPlayerRespawning=false;
    [SerializeField] private GameObject [] coin;
    [SerializeField] private int coinNum;
    public GameObject levelUpPanel;
    public TextMeshProUGUI winText;
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        if (_isPlayerRespawning == false)
        {
            _isPlayerRespawning = true;
            StartCoroutine(RespawnCoroutine());
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        _playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitSecond);
        _playerController.transform.position = _playerController.respawnPoint;//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _playerController.gameObject.SetActive(true);
        IsCoinActive();
        _isPlayerRespawning = false;
    }

    public void IsCoinActive()
    {

        for (int i = 0; i <= coinNum-1; i++)
        {
            coin[i].SetActive(true);
        }
        _playerController.score = 0;
        _playerController.scoreText.text = _playerController.score.ToString();
    }

    public void LevelUp()
    {
        levelUpPanel.SetActive(true);
        winText.text= "Level Completed...      " +
                      "Total Score: "+ _playerController.score;
        Invoke("NextLevel",2.3f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
