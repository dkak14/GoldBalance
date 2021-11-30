using System.Collections.Generic;
using Triggers;
public class TriggerDirectory {
    string directoryName = null;
    public string DirectoryName { get { return directoryName; } }
    List<TriggerAction> DirectoryTriggers = new List<TriggerAction>();
    public TriggerDirectory(string name) {
        directoryName = name;
    }
    public void AddTrigger(TriggerAction trigger) {
        DirectoryTriggers.Add(trigger);
    }
    public List<TriggerAction> GetTriggers() {
        return DirectoryTriggers;
    }
    public TriggerAction GetTrigger(int index) {
        return DirectoryTriggers[index];
    }
}
public class ItemDirectory<T> {
    string directoryName = null;
    public string DirectoryName { get { return directoryName; } }
    List<T> DirectoryItems = new List<T>();
    public ItemDirectory(string name) {
        directoryName = name;
    }
    public void AddItem(T trigger) {
        DirectoryItems.Add(trigger);
    }
    public List<T> GetItems() {
        return DirectoryItems;
    }
    public T Getitem(int index) {
        return DirectoryItems[index];
    }
}
