using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay {
    public class Controller : MonoBehaviour {
        #region Inspector
        public View view;
        public CircleSpawner circleSpawner;
        public GameClock gameClock;
        #endregion

        private Model model;

        private void Awake() {
            model = new Model();
            circleSpawner.SetCallbacks(CircleClicked, CircleTimedout);
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

            if (Input.GetKeyDown(KeyCode.Space))
                gameClock.Toggle(true);
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
}