using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
# if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    [SerializeField] TMP_Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        // if PlayerName is empty - we aren't coming from the main game
        if (string.IsNullOrEmpty(NameManager.Instance.PlayerName))
        {
            NameManager.Instance.LoadScore();
        }
        
        if ((!string.IsNullOrEmpty(NameManager.Instance.BestPlayer)) && (NameManager.Instance.Highscore > 0))
            highscoreText.text = "Best Score : " + NameManager.Instance.BestPlayer + " : " + NameManager.Instance.Highscore;
    }

    public void StartNew()
    {
        if (ProcessNameField())
            SceneManager.LoadScene(1);
    }

    public bool ProcessNameField()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            // make text red to nudge the player to enter his/her name
            inputField.placeholder.color = new Color(0.9528f, 0.0674f, 0.0674f, 0.9019f);
            return false;
        } else
        {
            NameManager.Instance.PlayerName = inputField.text;
            return true;
        }
    }

    public void Exit()
    {
        NameManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
