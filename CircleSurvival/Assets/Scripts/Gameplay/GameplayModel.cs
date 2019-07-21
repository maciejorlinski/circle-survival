public class GameplayModel {
    public float CurrentScore => currentPlayTime;
    public bool NewHighScore => CurrentScore > oldHighScore;

    private float currentPlayTime;
    private readonly ISaveService saveService;
    private readonly float oldHighScore;

    public GameplayModel() {
        saveService = new PlayerPrefsSaveService();
        oldHighScore = saveService.Load().highScore;
    }

    public void IncreaseGameTime(float value) => currentPlayTime += value;

    public void SaveResult() => saveService.Save(new SaveData(CurrentScore));
}
