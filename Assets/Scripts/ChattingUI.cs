using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChattingUI : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI text_ChatText;
    [SerializeField] private Scrollbar scrollbar_ChatPanel;
    [SerializeField] private TMP_InputField inputField_InputChat;
    [SerializeField] private Button button_Send;
    [SerializeField] private ScrollRect scrollRect_ChatHistory;

    private readonly Dictionary<NetworkConnectionToClient, string> _connectedNameDic = new Dictionary<NetworkConnectionToClient, string>();
    private string _localPlayerName;

    public override void OnStartServer()
    {
        _connectedNameDic.Clear();
    }

    public override void OnStartClient()
    {

    }

    
    public void OnClick_SendChat()
    {
        string currentInputChat = inputField_InputChat.text;

        if (!string.IsNullOrEmpty(currentInputChat))
        {
            SendChat(currentInputChat);
        }
    }

    [Command]
    private void SendChat(string chat, NetworkConnectionToClient sender = null)
    {
        if (_connectedNameDic.ContainsKey(sender))
        {
            // var player = sender.identity.GetComponent<Player>();
            // var playerName = player.playerName;
            // _connectedNameDic.Add(sender, playerName);
        }

        if (!string.IsNullOrEmpty(chat))
        {
            var senderName = _connectedNameDic[sender];
            OnRecvMessage(senderName, chat.Trim());
        }
    }

    [ClientRpc]
    private void OnRecvMessage(string senderName, string msg)
    {
        string formatedMsg = (senderName == _localPlayerName) ? $"<color=red>{senderName}:</color> {msg}" : $"<color=blue>{senderName}:</color>{msg}";
        AppendMessage(formatedMsg);
    }

    private void AppendMessage(string msg)
    {
        StartCoroutine(AppendAndScroll(msg));
    }

    private IEnumerator AppendAndScroll(string msg)
    {
        text_ChatText.text += msg + "\n";

        yield return null;

        scrollbar_ChatPanel.value = 0;
    }

    public void OnClick_Exit()
    {
        NetworkManager.singleton.StopHost();
    }

    public void OnValueChanged_ToggleButton(string input)
    {
        button_Send.interactable = !string.IsNullOrEmpty(input);
    }

    public void OnEndEdit_SendMsg(string input)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClick_SendChat();
        }
    }
}
