using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_MAnagement_Tracker
{
    public class ComboBoxItem
    {
        public int ID;
        public string Name { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
