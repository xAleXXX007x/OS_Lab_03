using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Lab_03
{
    class PhysicalPage : Page
    {
        public PhysicalPage(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return String.Format("Физ. страница {0}; содержимое '{1}';", Id, Data);
        }
    }
}
