using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_principal : MonoBehaviour
{
    [SerializeField] private string LevelAtual;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;

    public void jogar()
    {
        SceneManager.LoadScene(LevelAtual);
    }

    public void abrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void salvarOpcoes()
    {
        painelMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void sairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
