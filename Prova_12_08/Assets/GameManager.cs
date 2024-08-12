using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    int corDaVez, acertos, erros;

    int[] sequencia;

    [SerializeField] string[] nomes;
    private void Start()
    {
        GerarSequencia();
    }
    private void GerarSequencia()
    {
        corDaVez = 0;

        sequencia = new int [Random.Range(3, nomes.Length)];

        UIManager.instance.LimparTextos;

        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            UIManager.instance.AtualizarSequencia(nomes[sequencia[i]]);
        }
    }
    private void ChecarCor(int corIndex)
    {
        if (corIndex == corDaVez)
        {
            corDaVez++;

            if (corDaVez == sequencia.Length)
            {
                acertos++;

                UIManager.instance.AtualizarAcertos();

                GerarSequencia ();
            }
        }
        else
        {
            erros ++;

            UIManager.instance.AtualizarErros();
            GerarSequencia();
        }
    }
}
