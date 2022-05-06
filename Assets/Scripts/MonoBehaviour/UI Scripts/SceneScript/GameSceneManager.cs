using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;

public class GameSceneManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip click;

    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private ItemHolder inventory;
    [SerializeField] private ChoiceState state;
    [SerializeField] private Note note;

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
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            inventory.slots[i].Clear();
        }
        state.curState = 0.5f;
        note.order = 0;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            inventory.slots[i].Clear();
        }
        state.curState = 0.5f;
        note.order = 0;
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setSens(float sens)
    {
        var pov = cam.GetCinemachineComponent<CinemachinePOV>();
        pov.m_VerticalAxis.m_MaxSpeed = sens;
        pov.m_HorizontalAxis.m_MaxSpeed = sens;
    }
}
