public class MainMenuModel {
    public float HighScore => data.highScore;

    private SaveData data;
    private ISaveService saveService;

    public MainMenuModel() {
        saveService = new PlayerPrefsSaveService();
        data = saveService.Load();
    }
}
