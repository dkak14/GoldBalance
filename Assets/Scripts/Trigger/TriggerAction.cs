using UnityEngine;
using System;
namespace Triggers {
    public class TriggerAction : ScriptableObject {
        public string TriggerName {
            get
            {

                string name = this.GetType().ToString();
                if (name[0] == 'A' && name[1] == 'c') {
                    name = name.Substring(2, name.Length - 2);
                }
                else if (name.Length > 11 && name.Substring(0, 11) == "Triggers.Ac") {
                    name = name.Substring(11, name.Length - 11);
                }
                return name;
            }
        }
        public Action TriggerEnd;

        public void StartAction() { Action(); }
        public virtual bool Action() { return true; }
        public virtual TriggerAction GetCopyTrigger() {
            return null;
        }
    }
}
