using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string newLevel;

    void OnTriggerEnter2D (Collider2D obj) {
        if(obj.CompareTag("Player"))
            SceneManager.LoadScene(newLevel);
    }
}