using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Lab_03
{
    class PhysicalPage : Page
    {
        public PhysicalPage(int size, string data)
        {
            Size = size;
            Data = data;
        }

        public override string ToString()
        {
            return String.Format("Физ. страница {0}; размер {1}; содержимое '{2}';", Id, Size, Data);
        }
    }
}
