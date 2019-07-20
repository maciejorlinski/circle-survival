using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay {
    public class Controller : MonoBehaviour {
        #region Inspector
        public View view;
        #endregion

        private Model model;

        private void Awake() {
            model = new Model();
        }

        public void GameOver() {
            if (model.NewHighScore)
                model.SaveResult();
            view.DisplayGameSummary(model.CurrentScore, model.NewHighScore, BackToMenu);
        }

        private void BackToMenu() {
            SceneManager.LoadScene(Game.MAIN_MENU_SCENE_INDEX);
        }

        private void Update() {
            model.IncreaseGameTime(Time.deltaTime);
            view.UpdateScore(model.CurrentScore);

            if (Input.GetKeyDown(KeyCode.Space))
                GameOver();
        }
    }
}