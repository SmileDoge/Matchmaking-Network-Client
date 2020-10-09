using UnityEngine;
using Networking;
using WebSocketSharp;

namespace Assets.Networking
{
    public interface IServerCallbacks
    {
        void OnServerConnected();
        void OnServerDisconnected(CloseEventArgs ev);
        void OnServerError(ErrorEventArgs ev);
    }

    public class MonoBehaviourNetworkingCallbacks : MonoBehaviour, IServerCallbacks
    {
        public virtual void OnServerConnected()
        {

        }

        public virtual void OnServerDisconnected(CloseEventArgs ev)
        {

        }

        public virtual void OnServerError(ErrorEventArgs ev)
        {

        }

        void OnEnable()
        {
            MainNetwork.RegisterCallback(this);
        }

        
        void OnDisable()
        {
            MainNetwork.UnRegisterCallback(this);
        }
    }
}