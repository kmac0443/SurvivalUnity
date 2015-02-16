using System;
using System.Collections.Generic;

namespace Model.ModelObjects
{
    interface IUnity
    {
        void OnUpdate();
        void OnTime();
    }
}
