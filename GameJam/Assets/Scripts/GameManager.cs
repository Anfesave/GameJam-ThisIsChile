using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public static GameManager Instance;

    public string nextScene;
    public bool _isNight;

    public GameObject playerPrefab;

    private void Awake() => _instance = this;

    // Start is called before the first frame update
    private void Start() => DontDestroyOnLoad(this);

    public void LoadNextScene(Transform playerPos)
    {
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
        Instantiate(playerPrefab, playerPos.position, Quaternion.identity);
    }

    private void OnRenderObject()
    {
        if (_isNight)
        {
            SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();
            for (int i = 0; i < sprites.Length; i++)
                sprites[i].color = new Color(0.5f, 0.5f, 1);
        }
    }
}
