using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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

}
