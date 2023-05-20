using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;
    [HideInInspector] public UIManager UIManager;
    public Player currentPlayer;

    private void Awake()
    {
        #region SingletonInstantiation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
        #endregion

        UIManager = GetComponentInChildren<UIManager>();
    }

}
