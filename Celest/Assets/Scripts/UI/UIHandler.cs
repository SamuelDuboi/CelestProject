using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public UIDocument m_UiDocument;

    private void Awake()
    {
        m_UiDocument = GetComponent<UIDocument>();
    }
    private void OnEnable()
    {
        var root = m_UiDocument.rootVisualElement;
        Button settingButton = root.Q<Button>("SettingsButton");
        settingButton.clicked += ()=>OpenSetting(root);
        Button menuButton = root.Q<Button>("MenuButton");
        menuButton.clicked += () => OpenSetting(root);
    }

    void OpenSetting(VisualElement rootElement)
    {
        VisualElement settingElement = rootElement.Q<VisualElement>("Settings");
        if (settingElement.style.display.value == 0)
            settingElement.style.display = DisplayStyle.None;
        else
            settingElement.style.display = DisplayStyle.Flex;
    }
}
