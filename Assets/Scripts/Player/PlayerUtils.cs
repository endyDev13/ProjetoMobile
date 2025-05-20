using UnityEngine;

// Classe utilit�ria est�tica para m�todos relacionados ao jogador
public static class PlayerUtils
{
    // M�todo que retorna um prefixo de string com base na skin selecionada pelo jogador
    public static string GetCharacterPrefix()
    {
        string skinSelected = PlayerPrefs.GetString("skinSelected", "Menino"); // Recupera a skin salva no PlayerPrefs, ou "Menino" como valor padr�o se n�o existir

        return (skinSelected == "Menina") ? "Girl" : "Boy"; // Retorna "Girl" se a skin for "Menina", caso contr�rio, retorna "Boy"
    }
}
