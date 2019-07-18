namespace MainMenu {
    public class Model {
        public float HighScore => data.highScore;

        private SaveData data;
        private ISaveService saveService;

        public Model() {
            saveService = new PlayerPrefsSaveService();
            data = saveService.Load();
        }
    }
}