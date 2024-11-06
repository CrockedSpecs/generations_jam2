using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{
    private static audioManager instance;

    [Header("-----Musica-----")]
    public AudioSource levelMusic;
    public AudioSource menuMusic;

    public static audioManager Instance { get { return instance; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CheckActiveScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void CheckActiveScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainMenu")
        {
            PlayMenuMusic();
        }
        else if (currentScene.name == "level1")
        {
            StartCoroutine(StartLevelMusicWithDelay());
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckActiveScene();
    }

    public void PlayMenuMusic()
    {
        if (levelMusic.isPlaying)
            levelMusic.Stop();
        if (!menuMusic.isPlaying)
            menuMusic.Play();
    }

    public void PlayLevelMusic()
    {
        if (!levelMusic.isPlaying)
            levelMusic.Play();
    }

    IEnumerator StartLevelMusicWithDelay()
    {
        if (menuMusic.isPlaying)
            menuMusic.Stop();
        yield return new WaitForSeconds(3f);
        PlayLevelMusic();
    }
}
