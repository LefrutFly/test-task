using UnityEngine;

public class Screens : MonoBehaviour
{
    [SerializeField] private StartMenuScreen startScreen;
    [SerializeField] private InGameScreen inGameScreen;
    [SerializeField] private LoseScreen gameOverScreen;

    public StartMenuScreen StartScreen => startScreen;
    public InGameScreen InGameScreen => inGameScreen;
    public LoseScreen LoseScreen => gameOverScreen;


    private void Start()
    {
        EnableStartScreen();
    }

    public void EnableStartScreen()
    {
        startScreen.gameObject.SetActive(true);
        DisableInGameScreen();
        DisableLoseScreen();
    }

    public void EnableInGameScreen()
    {
        inGameScreen.gameObject.SetActive(true);
        DisableStartScreen();
        DisableLoseScreen();
    }

    public void EnableLoseScreen()
    {
        gameOverScreen.gameObject.SetActive(true);
        DisableStartScreen();
        DisableInGameScreen();
    }

    private void DisableStartScreen()
    {
        startScreen.gameObject.SetActive(false);
    }

    private void DisableInGameScreen()
    {
        inGameScreen.gameObject.SetActive(false);
    }

    private void DisableLoseScreen()
    {
        gameOverScreen.gameObject.SetActive(false);
    }
}
