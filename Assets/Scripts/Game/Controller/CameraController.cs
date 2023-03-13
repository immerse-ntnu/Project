using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            transform.position = player.transform.position + new Vector3(0, 1, -5);
        }
    }
}