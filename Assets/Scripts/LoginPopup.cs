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


}
