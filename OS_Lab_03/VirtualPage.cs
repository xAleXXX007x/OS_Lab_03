using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Lab_03
{
    class VirtualPage : Page
    {
        public DateTime LastUsed;

        public bool ReadOnly = false;

        public int ExternalId;

        public VirtualPage(Page page, string data, bool readOnly)
        {
            Data = data != null ? data : page.Data;
            ReadOnly = readOnly;
            LastUsed = DateTime.Now;
            ExternalId = page.Id;
        }

        public void Modify(string data)
        {
            if (!ReadOnly)
            {
                Data = data;
                LastUsed = DateTime.Now;
            } else
            {
                Console.WriteLine("Попытка изменения страницы только для чтения");
            }
        }

        public override string ToString()
        {
            return String.Format("Вирт. страница {0}; содержимое '{1}'; внешний ID {2}; ReadOnly {3}; время обр. {4};",
                        Id, Data, ExternalId, ReadOnly, LastUsed.Ticks);
        }
    }
}
