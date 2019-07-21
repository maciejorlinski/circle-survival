public class GameSummaryView : Prompt {
    private SummaryAnimation summaryAnimation;

    private void Awake() {
        summaryAnimation = GetComponent<SummaryAnimation>();
    }

    public void Show(float score, bool newHighScore) {
        base.Show();
        summaryAnimation.Play(score, newHighScore);
    }
}
