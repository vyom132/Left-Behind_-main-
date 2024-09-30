using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; void Awake() { instance = this; }
    public static Dictionary<string, float> volumes;


    [Header("-------------Scene-specific-------------")]
    [SerializeField]
    private bool inMainMenu;
    [SerializeField]
    private bool inDome;
    [SerializeField]
    private bool inGame;

    [Header("-----------------Preset-----------------")]
    [SerializeField]
    private List<GameObject> sound1;
    [SerializeField]
    private List<string> sound1Names;
    [SerializeField]
    private List<GameObject> sound2;
    [SerializeField]
    private List<string> sound2Names;


    void Start() {
        if (inMainMenu) {
            volumes = new Dictionary<string, float> {
                {"master", 1f}
            };
        }

        PlayMusic("walking", false);

        if (inDome) {
            PlayMusic("music", false);
            PlayMusic("intense music", true);
        } else if (inGame)
        {
            PlayMusic("music", true);
            PlayMusic("intense music", false);
        } else
        {
            PlayMusic("music", false);
            PlayMusic("intense music", false);
        }
    }

    public void PlayMusic(string name, bool active) {
        sound1[sound1Names.IndexOf(name)].SetActive(active);
    }

    public void PlaySound(string name, Transform pos) {
        Instantiate(sound2[sound2Names.IndexOf(name)], pos.position, Quaternion.identity);
    }

    public void StopPlaying() {
        foreach (var sound in sound1) {
            sound.SetActive(false);
        }
    }

    public void ResetVolumes() {
        volumes = new Dictionary<string, float> {
            {"master", 1f}
        };
    }
}
