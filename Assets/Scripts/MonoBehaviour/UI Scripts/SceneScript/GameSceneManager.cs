using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameSceneManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip click;

    [SerializeField] private ItemHolder inventory;
    [SerializeField] private ChoiceState state;

    public AudioMixer audioMixer;

    public static void loadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            inventory.slots[i].Clear();
        }
        state.curState = 0.5f;
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
