using System;
using System.Collections.Generic;
using System.Text;

namespace DjunPro
{
    public class Account
        // show accounts in the listbox
    {
        int id, type;
        string name;

        public Account(int id, string name, int type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public override string ToString()
        {
            string ac_type;

            if (type == 0)
                ac_type = "Secretary";
            else if (type == 1)
                ac_type = "Doctor";
            else
                ac_type = "Patient";

            return ac_type + ":" + id.ToString() + " - " + name;
        }

        public int getId()
        {
            return id;
        }
    }
}
