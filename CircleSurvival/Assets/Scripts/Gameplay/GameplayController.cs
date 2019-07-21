using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
    #region Inspector
    public GameplayView view;
    public CircleSpawner circleSpawner;
    public GameClock gameClock;
    #endregion

    private GameplayModel model;

    private void Awake() {
        model = new GameplayModel();
        circleSpawner.SetCallbacks(CircleClicked, CircleTimedout);
    }

    private void Start() {
        view.PlayIntro(StartGame);
    }

    private void StartGame() {
        view.hud.SetActive(true);
        gameClock.Toggle(true);
    }

    public void GameOver() {
        gameClock.Toggle(false);
        if (model.NewHighScore)
            model.SaveResult();
        view.DisplayGameSummary(model.CurrentScore, model.NewHighScore, BackToMenu);
    }

    private void BackToMenu() {
        SceneManager.LoadScene(Game.MAIN_MENU_SCENE_INDEX);
    }

    private void Update() {
        model.IncreaseGameTime(gameClock.DeltaTime);
        view.UpdateScore(model.CurrentScore);
    }

    private void CircleClicked(CircleType circleType) {
        if (circleType == CircleType.Black)
            GameOver();
    }

    private void CircleTimedout(CircleType circleType) {
        if (circleType == CircleType.Green)
            GameOver();
    }
}
