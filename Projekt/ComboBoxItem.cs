using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    /// <summary>
    /// This class represent the id and the name which did the knighttour simulation
    /// It also include the timestamp when the simulation occured
    /// </summary>
    public class ComboBoxItem
    {
        string name;
        string created;
        string hiddenValue;

        //Constructor
        public ComboBoxItem(string id, string name, string created)
        {
            hiddenValue = id;
            this.name = name;
            this.created = created;
        }

        //The id for the person who dif the sumulation
        public string HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        //Override ToString method and return just the name and the timestamp
        public override string ToString()
        {
            return String.Format("{0,-20} {1,-20}", created, name);
        }
    }
}
