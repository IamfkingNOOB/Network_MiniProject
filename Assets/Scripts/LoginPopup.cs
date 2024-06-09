using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPopup : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField inputField_ipAddress;
    [SerializeField] private TMP_InputField inputField_userName;

    [SerializeField] private Button button_startAsHost;
    [SerializeField] private Button button_startAsClient;

    [SerializeField] private TextMeshProUGUI text_Error;

    private void Awake()
    {
        inputField_ipAddress.text = "localhost";

        inputField_userName.onValueChanged.RemoveAllListeners();
        inputField_userName.onValueChanged.AddListener((text) =>
        {
            bool isValueChanged = !string.IsNullOrEmpty(text);

            button_startAsHost.interactable = isValueChanged;
            button_startAsClient.interactable = isValueChanged;
        });
    }
}
