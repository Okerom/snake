using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] TMP_Text nickname;
    [SyncVar(hook = nameof(HandlePlayerNameUpdated))]
    string playerName;
    void HandlePlayerNameUpdated(string oldtext, string newtext)
    {
        nickname.text = newtext;
    }

    public override void OnStartServer()
    {
        playerName = $"player {connectionToClient.connectionId}";
    }
}
