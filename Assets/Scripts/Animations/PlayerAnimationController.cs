using UnityEngine;
using System.Collections.Generic;

// Classe respons�vel por controlar as anima��es do jogador
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator; // Refer�ncia ao componente Animator
    private Dictionary<string, int> animationBools; // Dicion�rio que armazena os hashes das anima��es booleanas
    private string prefix; // Prefixo do personagem ("Boy" ou "Girl") para acessar as anima��es corretas

    // M�todo de inicializa��o do controlador de anima��o
    public void Init(Animator animatorRef, string characterPrefix)
    {
        animator = animatorRef; // Define o animator recebido como refer�ncia
        prefix = characterPrefix; // Define o prefixo do personagem

        animationBools = new Dictionary<string, int>(); // Inicializa o dicion�rio de anima��es

        // Associa os nomes das anima��es aos hashes correspondentes de acordo com o prefixo (Boy ou Girl)
        if (prefix == "Boy")
        {
            animationBools["Idle"] = AnimationHashes.BoyIdle;
            animationBools["XMovement"] = AnimationHashes.BoyXMovement;
            animationBools["YMovement"] = AnimationHashes.BoyYMovement;
            animationBools["YMovementDown"] = AnimationHashes.BoyYMovementDown;
        }
        else if (prefix == "Girl")
        {
            animationBools["Idle"] = AnimationHashes.GirlIdle;
            animationBools["XMovement"] = AnimationHashes.GirlXMovement;
            animationBools["YMovement"] = AnimationHashes.GirlYMovement;
            animationBools["YMovementDown"] = AnimationHashes.GirlYMovementDown;
        }

        Debug.Log("Init chamado com prefixo: " + characterPrefix);
    }

    // M�todo que define qual anima��o deve ser ativada com base nos valores de movimento horizontal e vertical
    public void SetMovement(float horizontal, float vertical)
    {
        ResetAllBools(); // Desativa todas as anima��es antes de ativar a correta

        // Ativa a anima��o com base na dire��o do movimento
        if (horizontal != 0)
        {
            animator.SetBool(animationBools["XMovement"], true);
        }
        else if (vertical > 0)
        {
            animator.SetBool(animationBools["YMovement"], true);
        }
        else if (vertical < 0)
        {
            animator.SetBool(animationBools["YMovementDown"], true);
        }
        else
        {
            animator.SetBool(animationBools["Idle"], true); // Ativa a anima��o de idle se n�o houver movimento
        }
    }

    // M�todo auxiliar que desativa todas as anima��es booleanas
    private void ResetAllBools()
    {
        foreach (var hash in animationBools.Values)
        {
            animator.SetBool(hash, false); // Define todos os bools de anima��o como false
        }
    }
}

