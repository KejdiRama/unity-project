using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objToHide;

    [Header("Scenes to Load")]
    [SerializeField] private SceneField _persistentGameplay;
    [SerializeField] private SceneField _levelScene;

    private List<AsyncOperation> _scenesToLoad = new List<AsyncOperation>();

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        HideMenu();
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(_persistentGameplay));
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(_levelScene,LoadSceneMode.Additive));
    }

    private void HideMenu() { 
        foreach (var obj in _objToHide)
        {
            obj.SetActive(false);
        }
    }
}
