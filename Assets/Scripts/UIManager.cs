using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button _startButton, _quitButton;

    private void Awake()
    {
        _startButton = GameObject.FindGameObjectWithTag("Start").GetComponent<Button>();
        _quitButton = GameObject.FindGameObjectWithTag("Quit").GetComponent<Button>();

        _startButton.onClick.AddListener(StartMethod);
        _quitButton.onClick.AddListener(QuitMethod);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartMethod);
        _quitButton.onClick.RemoveListener(QuitMethod);
    }

    private void StartMethod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitMethod()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        
#endif
       
    }
}
