using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    int corDaVez, acertos, erros;

    int[] sequencia;

    [SerializeField] string[] nomes;
    public void Start()
    {
        GerarSequencia();
    }
    public void GerarSequencia()
    {
        corDaVez = 0;

        sequencia = new int [Random.Range(3, nomes.Length)];

        UIManager.Instance.LimparTexto();

        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            UIManager.Instance.AtualizarSequencia(nomes[sequencia[i]]);
        }
    }
    public void ChecarCor(int corIndex)
    {
        if (corIndex == sequencia[corDaVez])
        {
            corDaVez++;

            if (corDaVez == sequencia.Length)
            {
                acertos++;

                UIManager.Instance.AtualizarAcertos(acertos);

                GerarSequencia ();
            }
        }
        else
        {
            erros ++;

            UIManager.Instance.AtualizarErros(erros);
            GerarSequencia();
        }
    }
}
