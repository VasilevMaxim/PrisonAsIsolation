using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Items
{
    [Serializable]
    internal class Storage
    {
        internal event Action<ResourceData[]> Change;

        public IEnumerable<ResourceData> Resources => _resources;
        [SerializeField] private ResourceData[] _resources;

        internal Storage(int size)
        {
            if (size < 0)
                throw new ArgumentException();

            _resources = new ResourceData[size];
        }

        internal bool IsFull()
        {
            var index = Array.FindIndex(_resources, el => el == ResourceData.Null);
            return index == -1;
        }
        internal bool IsFree()
        {
            var index = Array.FindIndex(_resources, el => el != ResourceData.Null);
            return index == -1;
        }

        internal void PushFirstFree(Item item)
        {
            var index = Array.FindIndex(_resources, el => el == ResourceData.Null);
            if (index == -1)
                throw new Exception();

            Push(index, item);
        }
        internal void PushFirstFree(ResourceData resource)
        {
            var index = Array.FindIndex(_resources, el => el == ResourceData.Null);
            if (index == -1)
                throw new Exception();

            Push(index, resource);
        }
        internal ResourceData PopFirstOccupied()
        {
            var index = Array.FindIndex(_resources, el => el != ResourceData.Null);
            if (index == -1)
                throw new Exception();

            return Pop(index);
        }

        internal ResourceData Pop(int index)
        {
            var rezult = _resources[index];
            _resources[index] = ResourceData.Null;

            Change?.Invoke(_resources);

            return rezult;
        }
        internal void Push(int index, ResourceData resource)
        {
            if (index < 0 ||
                index > _resources.Length ||
                _resources[index] != ResourceData.Null)
                throw new ArgumentException();

            _resources[index] = resource;
            Change?.Invoke(_resources);
        }
        internal void Push(int index, Item item)
        {
            if (index < 0 ||
                index > _resources.Length ||
                _resources[index] != ResourceData.Null ||
                item == null)
                throw new ArgumentException();

            _resources[index] = new ResourceData(item.Id);
            Change?.Invoke(_resources);
        }
    }
}