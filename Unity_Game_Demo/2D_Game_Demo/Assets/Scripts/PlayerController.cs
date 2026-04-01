using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private float score = 0f;
    public float scoreMultiplier = 10f;
    private float elapsedTime = 0f;
    public float trustforce = 1f;
    public float maxSpeed = 5f;
    public GameObject boostFlame;
    public UIDocument uiDocument;
    private Label scoreText;
    private Label highScoreText;
    public GameObject explosionEffect;
    public GameObject borderParent;
    private Button restartButton;
    private DropdownField themeDropdown;
    private bool isGameOver = false;
    private const string ThemePrefKey = "SelectedTheme";
    private readonly List<string> themeOptions = new List<string> { "Sunset", "Lime", "Neon" };
    private string currentTheme;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        highScoreText = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");
        highScoreText.style.display = DisplayStyle.None;
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;

        themeDropdown = uiDocument.rootVisualElement.Q<DropdownField>("ThemeDropdown");

        currentTheme = PlayerPrefs.GetString(ThemePrefKey, themeOptions[0]);
        if (!themeOptions.Contains(currentTheme))
        {
            currentTheme = themeOptions[0];
        }

        ConfigureThemeDropdown();
        ApplyTheme(currentTheme);
        themeDropdown.style.display = DisplayStyle.None;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        if (Mouse.current.leftButton.isPressed)
        {
            // calculate the direction from the player to the mouse position
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Debug.Log("Mouse position: " + mosPos);

            // add force towards the mouse position
            Vector2 direction = (mosPos - transform.position).normalized;
            transform.up = direction; // Rotate the player to face
            rb.AddForce(transform.up * trustforce);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boostFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boostFlame.SetActive(false);
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;
        int currentScore = Mathf.FloorToInt(score);
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        int updatedHighScore = Mathf.Max(savedHighScore, currentScore);

        if (updatedHighScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", updatedHighScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "High Score: " + updatedHighScore;
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        restartButton.style.display = DisplayStyle.Flex;
        highScoreText.style.display = DisplayStyle.Flex;

        borderParent.SetActive(false);

        themeDropdown.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ConfigureThemeDropdown()
    {
        if (themeDropdown == null)
        {
            return;
        }

        themeDropdown.choices = themeOptions;
        themeDropdown.value = currentTheme;
        themeDropdown.label = "Theme";
        themeDropdown.RegisterValueChangedCallback(evt =>
        {
            currentTheme = evt.newValue;
            ApplyTheme(currentTheme);
            PlayerPrefs.SetString(ThemePrefKey, currentTheme);
            PlayerPrefs.Save();
        });
    }

    void ApplyTheme(string themeName)
    {
        Color borderColor = new Color(0.98f, 0.75f, 0.20f);
        Color panelColor = new Color(0.83f, 0.37f, 0.32f);
        Color buttonColor = new Color(0.25f, 0.56f, 0.86f);

        switch (themeName)
        {
            case "Lime":
                borderColor = new Color(0.57f, 0.84f, 0.19f);
                panelColor = new Color(0.98f, 0.35f, 0.43f);
                buttonColor = new Color(0.17f, 0.51f, 0.78f);
                break;
            case "Neon":
                borderColor = new Color(0.95f, 0.95f, 0.02f);
                panelColor = new Color(1.00f, 0.20f, 0.33f);
                buttonColor = new Color(0.11f, 0.83f, 0.93f);
                break;
        }

        ApplyBorderTheme(borderColor);
        ApplyUiTheme(panelColor, buttonColor, borderColor);
    }

    void ApplyBorderTheme(Color borderColor)
    {
        if (borderParent == null)
        {
            return;
        }

        SpriteRenderer[] borderRenderers = borderParent.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (SpriteRenderer spriteRenderer in borderRenderers)
        {
            spriteRenderer.color = borderColor;
        }
    }

    void ApplyUiTheme(Color panelColor, Color buttonColor, Color borderColor)
    {
        if (scoreText != null)
        {
            scoreText.style.borderBottomColor = borderColor;
            scoreText.style.borderTopColor = borderColor;
            scoreText.style.borderLeftColor = borderColor;
            scoreText.style.borderRightColor = borderColor;
            scoreText.style.color = Color.white;
        }

        if (highScoreText != null)
        {
            highScoreText.style.backgroundColor = panelColor;
            highScoreText.style.color = Color.white;
            highScoreText.style.borderBottomColor = borderColor;
            highScoreText.style.borderTopColor = borderColor;
            highScoreText.style.borderLeftColor = borderColor;
            highScoreText.style.borderRightColor = borderColor;
        }

        if (restartButton != null)
        {
            restartButton.style.backgroundColor = buttonColor;
            restartButton.style.color = Color.white;
        }

        if (themeDropdown != null)
        {
            themeDropdown.style.backgroundColor = buttonColor;
            themeDropdown.style.color = Color.white;
            themeDropdown.style.borderBottomColor = borderColor;
            themeDropdown.style.borderTopColor = borderColor;
            themeDropdown.style.borderLeftColor = borderColor;
            themeDropdown.style.borderRightColor = borderColor;
        }
    }
}
