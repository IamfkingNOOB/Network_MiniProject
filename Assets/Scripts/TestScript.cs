using Mirror;
using UnityEngine;

public class TestScript : NetworkBehaviour
{
    #region Overrides

    // Like Start(), but only called on server and host.
    // Called when behaviour is spawned on server.
    public override void OnStartServer() { Debug.Log("OnStartServer()"); }

    // Stop event, only called on server and host.
    // Called when behaviour is destroyed or unspawned on server.
    public override void OnStopServer() { Debug.Log("OnStopServer()"); }

    // Override to do custom serialization (instead of of SyncVars/SyncLists). Use OnDeserialize too.
    // Called when behaviour is serialize before it is sent to client, when overriding make sure to call base.OnSerialize
    public override void OnSerialize(NetworkWriter writer, bool initialState) { Debug.Log("OnSerialize()"); }

    // Like Start(), but only called on client and host.
    // Called when behaviour is spawned on client.
    public override void OnStartClient() { Debug.Log("OnStartClient()"); }

    // Like Start(), but only called for objects the client has authority over.
    // Called when behaviour has authority when it is spawned (eg. local player).
    // Called when behaviour is given authority by the server.
    public override void OnStartAuthority() { Debug.Log("OnStartAuthority()"); }

    // Like Start(), but only called on client and host for the local player object.
    // Called when the behaviour is on the local player object.
    public override void OnStartLocalPlayer() { Debug.Log("OnStartLocalPlayer()"); }

    // Stop event, only called for objects the client has authority over.
    // Called when authority is taken from the object (eg. local player is replaced but not destroyed).
    public override void OnStopAuthority() { Debug.Log("OnStopAuthority()"); }

    // Stop event, only called on client and host.
    // Called when object is destroyed on client by the ObjectDestroyMessage or ObjectHideMessage messages.
    public override void OnStopClient() { Debug.Log("OnStopClient()"); }

    #endregion Overrides

    #region Attributes

    // Prevents clients from running this method. Prints a warning if a client tries to execute this method.
    // Only a server can call the method (throws a warning when called on a client).
    [Server]

    private void Server() { Debug.Log("[Server]"); }

    // Prevent clients from running this method. No warning is thrown.
    // Same as Server but does not throw a warning when called on client.
    [ServerCallback]
    private void ServerCallback() { Debug.Log("[ServerCallback]"); }

    // Prevents the server from running this method. Prints a warning if the server tries to execute this method.
    // Only a Client can call the method (throws a warning when called on the server).
    [Client]
    private void Client() { Debug.Log("[Client]"); }

    // Prevents the server from running this method. No warning is printed.
    // Same as Client but does not throw a warning when called on server.
    [ClientCallback]
    private void ClientCallback() { Debug.Log("[ClientCallback]"); }

    // Call this from a client to run this function on the server. Make sure to validate input etc. It's not possible to call this from a server.
    // Use this as a wrapper around another function, if you want to call it from the server too.
    [Command]
    private void Command() { Debug.Log("[Command]"); }

    // The server uses a Remote Procedure Call (RPC) to run this function on clients.
    [ClientRpc]
    private void ClientRpc() { Debug.Log("[ClientRpc]"); }

    // The server uses a Remote Procedure Call (RPC) to run this function on a specific client.
    // This is an attribute that can be put on methods of Network Behaviour classes to allow them to be invoked on clients from a server.
    // Unlike the ClientRpc attribute, these functions are invoked on one individual target client, not all of the ready clients.
    [TargetRpc]
    private void TargetRpc() { Debug.Log("[TargetRpc]"); }

    // SyncVars are used to synchronize a variable from the server to all clients automatically.
    // Value must be changed on server, not directly by clients. Hook parameter allows you to define a client-side method to be invoked when the client gets an update from the server.
    // Don't assign them from a client, it's pointless. Don't let them be null, you will get errors.
    // You can use int, long, float, string, Vector3 etc. (all simple types) and Network Identity and game object if the game object has a Network Identity attached to it.
    // You can use SyncVar Hooks to run code on clients when they receive updates from the server.
    [SyncVar]
    private int syncVar;

    #endregion Attributes

}
