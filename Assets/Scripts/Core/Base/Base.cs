using Core.Interface;
using UnityEngine;

namespace Core.Base
{
    public abstract class Base : MonoBehaviour, ISubscribable
    {
        protected virtual void OnEnable()
        {
            Subscribe();
        }

        protected virtual void OnDisable()
        {
            Unsubscribe();
        }


        public virtual void Subscribe()
        {
        }

        public virtual void Unsubscribe()
        {
        }

        protected virtual void SubscribeChild()
        {
            var childArray = GetComponentsInChildren<Base>();

            foreach (var child in childArray) child.Subscribe();
        }

        protected virtual void UnsubscribeChild()
        {
            var childArray = GetComponentsInChildren<Base>();

            foreach (var child in childArray) child.Unsubscribe();
        }

        public virtual void ShowInHierarchy()
        {
            hideFlags = HideFlags.None;
        }

        public virtual void HideInHierarchy()
        {
            hideFlags = HideFlags.HideInHierarchy;
        }

        protected virtual void Active()
        {
            gameObject.SetActive(true);
        }

        protected virtual void DeActive()
        {
            gameObject.SetActive(false);
        }
    }
}