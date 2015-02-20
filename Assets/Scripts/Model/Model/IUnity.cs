using System;
using System.Collections.Generic;

namespace Model.ModelObjects
{
    public interface IUnity
    {
        void OnUpdate();
        void OnTime();
    }
}
