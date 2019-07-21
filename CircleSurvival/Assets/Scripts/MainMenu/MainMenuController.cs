using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    #region Inspector
    public MainMenuView view;
    #endregion

    private MainMenuModel model;

    public void NewGame() => SceneManager.LoadScene(Game.GAME_SCENE_INDEX);

    private void Start() {
        model = new MainMenuModel();
        view.SetHighScore(model.HighScore);
    }
}
