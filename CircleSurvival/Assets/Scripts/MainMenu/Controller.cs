using UnityEngine.SceneManagement;
using UnityEngine;

namespace MainMenu {
    public class Controller : MonoBehaviour {
        #region Inspector
        public View view;
        #endregion

        private Model model;

        public void NewGame() => SceneManager.LoadScene(Game.GAME_SCENE_INDEX);

        private void Start() {
            model = new Model();
            view.SetHighScore(model.HighScore);
        }
    }
}