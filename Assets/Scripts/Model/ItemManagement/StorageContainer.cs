﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class StorageContainer
{
    public delegate void StorageContainerDelegate(StorageContainer sender);
    public static event StorageContainerDelegate StorageContainerChangedEvent;

    private int maxCapacity;
    private int currentCapacity;
    private List<Item> items;

    public StorageContainer()
    {
        this.MaxCapacity = 100;
        this.Capacity = 0;
        this.Items = new List<Item>();
    }

    public bool Contains(Guid id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == id)
            {
                return true;
            }
        }
        return false;
    }

	public bool ContainsType(params Type[] types)
	{
		foreach (Item item in items)
		{
			foreach (Type type in types) {
				if (item.ItemType == type)
				{
					return true;
				}
			}
		}
		return false;
	}

    public int MaxCapacity
    {
        get { return this.maxCapacity; }
        set
        {
            this.maxCapacity = value;
            // Negative Threshold
            if (this.maxCapacity < 0)
            {
                this.maxCapacity = 0;
            }
            // Current Threshold
            if (this.currentCapacity > this.maxCapacity)
            {
                this.currentCapacity = this.maxCapacity;
            }
            Changed();
        }
    }

    public int Capacity
    {
        get { return this.currentCapacity; }
        set
        {
            this.currentCapacity = value;
            // Negative Threshold
            if (this.currentCapacity < 0)
            {
                this.currentCapacity = 0;
            }
			Changed();
        }
    }

    public List<Item> Items
    {
        get
        {
            return this.items;
        }
        set
        {
            if (value != null)
            {
                this.items = value;
            }
            else
            {
                this.items = new List<Item>();
				Changed();
            }
        }
    }

    public bool AddItem(Item item)
    {
        if (item == null)
        {
            return false;
        }
        // Duplicate Check
        if (this.Contains(item.ID))
        {
            return false;
        }
        // Capacity Check
        if (this.Capacity + item.Girth <= this.MaxCapacity)
        {
            this.items.Add(item);
            this.Capacity += item.Girth;
			Changed();
            return true;
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        if (null == item)
        {
            return false;
        }

        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i].ID == item.ID)
            {
                this.Capacity -= this.items[i].Girth;
                this.items.RemoveAt(i);
				Changed();
                return true;
            }
        }
        return false;
    }

    private void Changed()
    {
        if (StorageContainerChangedEvent != null)
        {
            StorageContainerChangedEvent(this);
        }
    }
}
