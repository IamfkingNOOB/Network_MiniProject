using Mirror;
using UnityEngine;

public class TestScript : NetworkBehaviour
{
    #region Overrides

    public override void OnStartClient() { }

    public override void OnStartServer() { }

    #endregion Overrides

    #region Attributes

    // Prevents clients from running this method. Prints a warning if a client tries to execute this method.
    // Only a server can call the method (throws a warning when called on a client).
    [Server]

    private void Server()
    {
        Debug.Log("Server");
    }

    // Prevent clients from running this method. No warning is thrown.
    // Same as Server but does not throw a warning when called on client.
    [ServerCallback]
    private void ServerCallback()
    {
        Debug.Log("ServerCallback");
    }

    // Prevents the server from running this method. Prints a warning if the server tries to execute this method.
    // Only a Client can call the method (throws a warning when called on the server).
    [Client]
    private void Client()
    {
        Debug.Log("Client");
    }

    // Prevents the server from running this method. No warning is printed.
    // Same as Client but does not throw a warning when called on server.
    [ClientCallback]
    private void ClientCallback()
    {
        Debug.Log("ClientCallback");
    }

    // Call this from a client to run this function on the server. Make sure to validate input etc. It's not possible to call this from a server.
    // Use this as a wrapper around another function, if you want to call it from the server too.
    [Command]
    private void Command()
    {
        Debug.Log("Command");
    }

    // The server uses a Remote Procedure Call (RPC) to run this function on clients.
    [ClientRpc]
    private void ClientRpc()
    {
        Debug.Log("ClientRpc");
    }

    // The server uses a Remote Procedure Call (RPC) to run this function on a specific client.
    // This is an attribute that can be put on methods of Network Behaviour classes to allow them to be invoked on clients from a server.
    // Unlike the ClientRpc attribute, these functions are invoked on one individual target client, not all of the ready clients.
    [TargetRpc]
    private void TargetRpc()
    {
        Debug.Log("TargetRpc");
    }

    // SyncVars are used to synchronize a variable from the server to all clients automatically.
    // Value must be changed on server, not directly by clients. Hook parameter allows you to define a client-side method to be invoked when the client gets an update from the server.
    // Don't assign them from a client, it's pointless. Don't let them be null, you will get errors.
    // You can use int, long, float, string, Vector3 etc. (all simple types) and Network Identity and game object if the game object has a Network Identity attached to it.
    // You can use SyncVar Hooks to run code on clients when they receive updates from the server.
    [SyncVar]
    private int syncVar;

    #endregion Attributes

}
