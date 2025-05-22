using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Image iconPlayer;
    public Sprite boySprite;
    public Sprite girlSprite;
    private bool switchSettings = false;
    public TextMeshProUGUI namePlayer; 

    private void Start()
    {
        if (PlayerSpawn.PlayerSkin == "Boy") iconPlayer.sprite = boySprite;
        else iconPlayer.sprite = girlSprite;
        namePlayer.text = ScreenCharacter.inputField.text.ToUpper(); // Atualiza o nome do jogador TUDO EM MAIÚSCULO
    }

    public void SwitchSetting()
    {
        switchSettings = !switchSettings;

        if(!switchSettings) settingsPanel.SetActive(true);
        else settingsPanel.SetActive(false);
    }

    public void MenuScreen()
    {
        switchSettings = false; // Reseta o estado do switch
        PlayerSpawn.PlayerSkin = ""; // Limpa a skin do jogador
        ScreenCharacter.inputField.text = ""; // Limpa o campo de texto

        SceneManager.LoadScene("MenuScene"); // Carrega a cena do menu
    }
}
