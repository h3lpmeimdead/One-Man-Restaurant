using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHandler : MonoBehaviour
{
    public static CreditHandler instance;

    [SerializeField] private GameObject m_CreditUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnShowCredit()
    {
        m_CreditUI.SetActive(true);
    }

    public void OnDisableCredit()
    {
        m_CreditUI.SetActive(false);
    }
}
