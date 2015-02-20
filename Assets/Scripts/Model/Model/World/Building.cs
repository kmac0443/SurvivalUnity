using Model.ModelObjects.ItemManagement;
using System;
using System.Collections.Generic;

namespace Model.Building
{
    public class Building
    {
        private StorageContainer storage;

        public Building()
        {
            Storage = new StorageContainer();
        }

        public StorageContainer Storage
        {
            get { return this.storage; }
            set { this.storage = value; }
        }
    }
}
