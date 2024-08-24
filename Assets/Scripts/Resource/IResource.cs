using System;

namespace Resource
{
    interface IResource
    {
        int Amount { get; }
        void Add();
        void Remove();
    }
}
