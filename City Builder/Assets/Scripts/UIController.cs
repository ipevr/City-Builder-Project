using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button buildResidentialAreaButton = null;
    [SerializeField] Button cancelActionButton = null;
    [SerializeField] GameObject cancelActionPanel = null;

    public UnityEvent OnBuildAreaHandler;
    public UnityEvent OnCancelActionHandler;


    #region Unity Callbacks

    private void Start()
    {
        cancelActionPanel.SetActive(false);
        buildResidentialAreaButton.onClick.AddListener(OnBuildResidentialAreaButtonClicked);
        cancelActionButton.onClick.AddListener(OnCancelActionButtonClicked);
    }

    private void OnDisable()
    {
        buildResidentialAreaButton.onClick.RemoveListener(OnBuildResidentialAreaButtonClicked);
        cancelActionButton.onClick.RemoveListener(OnCancelActionButtonClicked);
    }

    #endregion


    #region Private Methods

    private void OnBuildResidentialAreaButtonClicked()
    {
        cancelActionPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancelActionButtonClicked()
    {
        cancelActionPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
    }

    #endregion
}
