using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int FadeOut = Animator.StringToHash("FadeIn");

    public void OnRestartButtonCLicked()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        _animator.SetTrigger(FadeOut);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(0);
    }

}
