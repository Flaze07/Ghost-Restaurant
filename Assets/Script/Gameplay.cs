using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static GameObject instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MinigameCookingGodong")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
            if(miniManager.fromMinigame)
            {
                miniManager.fromMinigame = false;
                Player player = GetComponentInChildren<Player>();
                player.changeKoin(miniManager.coinChanges);
                player.changeFP(miniManager.fameChanges);
            }
        }
    }
}
