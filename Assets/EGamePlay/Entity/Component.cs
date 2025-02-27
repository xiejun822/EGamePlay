﻿using System;

namespace EGamePlay
{
    public class Component : IDisposable
    {
        public Entity Entity { get; set; }
        public bool IsDisposed { get; set; }
        public virtual bool DefaultEnable { get; set; } = true;
        private bool enable = false;
        public bool Enable
        {
            set
            {
                if (enable == value) return;
                enable = value;
                if (enable) OnEnable();
                else OnDisable();
            }
            get
            {
                return enable;
            }
        }
        public bool Disable => enable == false;


        public T GetEntity<T>() where T : Entity
        {
            return Entity as T;
        }

        public virtual void Setup()
        {

        }

        public virtual void Setup(object initData)
        {

        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnDestroy()
        {

        }

        public void Dispose()
        {
            if (Entity.EnableLog) Log.Debug($"{GetType().Name}->Dispose");
            IsDisposed = true;
        }

        public T Publish<T>(T TEvent) where T : class
        {
            Entity.Publish(TEvent);
            return TEvent;
        }

        public void Subscribe<T>(Action<T> action) where T : class
        {
            Entity.Subscribe(action);
        }

        public void UnSubscribe<T>(Action<T> action) where T : class
        {
            Entity.UnSubscribe(action);
        }
    }
}