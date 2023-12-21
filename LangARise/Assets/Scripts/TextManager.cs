using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private string[] differentVariantsOfText;
    [SerializeField] private TextMeshProUGUI changedTextOnPanel;

    public void ChangeText(int numberOfTextButton)
    {
        changedTextOnPanel.text = differentVariantsOfText[numberOfTextButton];
    }
}
//