using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectorHandler : MonoBehaviour
{
    public Image selectorImg;
    public MenuHandler menuHandler;
    [SerializeField]
    private Event[] selectionLocations;
    int selection = 0;
    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            selection = (selection + 1) % selectionLocations.Length;
            UpdateSelection();
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            selection = selection - 1;
            if (selection < 0) {
                selection = selectionLocations.Length - 1;
            }
            UpdateSelection();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            menuHandler.RegisterEvent(selectionLocations[selection].eventName);
        }
    }

    void UpdateSelection() {

        selectorImg.rectTransform.anchoredPosition3D = selectionLocations[selection].rectTransform.anchoredPosition3D;
    }
}

[Serializable]
class Event {
    public string eventName;
    public RectTransform rectTransform;
}
