using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Lab_03
{
    class MemoryManager
    {
        private Memory HDD;
        private Memory RAM;

        public MemoryManager(int HDDSize, int RAMSize)
        {
            HDD = new Memory(HDDSize);
            RAM = new Memory(RAMSize);
        }

        public void AddPhysicalPage(PhysicalPage page)
        {
            HDD.AddPage(page);

            Console.WriteLine("На HDD загружена новая " + page);
        }

        public void LoadVirtualPage(int index, string data, bool readOnly=false)
        {
            Page page = HDD.GetPage(index);
            Page virtualPage = new VirtualPage(page, data, readOnly);

            try
            {
                Console.WriteLine("В RAM загружается новая " + virtualPage);
                RAM.AddPage(virtualPage);
            } catch (Exception e)
            {
                Console.WriteLine("Недостаточно виртуальной памяти");

                VirtualPage p = RAM.ReplacePage(virtualPage) as VirtualPage;

                Console.WriteLine("Выгружена " + p);

                SavePageToHDD(p);
            }
        }

        public void SavePageToHDD(VirtualPage page)
        {
            Page HDDPage = HDD.GetPage(page.ExternalId);

            if (!page.ReadOnly && !page.Data.Equals(HDDPage))
            {
                HDDPage.Data = page.Data;
            }
        }

        public void UpdateVirtualPage(int index, string data)
        {
            Page page = RAM.GetPage(index);

            if (page == null)
            {
                return;
            }

            (page as VirtualPage).Modify(data);
        }

        public void SaveRAMToHDD()
        {
            List<Page> pages = RAM.DumpPages();

            foreach(Page page in pages)
            {
                SavePageToHDD(page as VirtualPage);
            }
        }

        public void PrintContains()
        {
            Console.WriteLine("HDD ({0}/{1}):", HDD.GetSize(), HDD.GetMaxSize());
            HDD.PrintContains();
            Console.WriteLine("RAM ({0}/{1}):", RAM.GetSize(), RAM.GetMaxSize());
            RAM.PrintContains();
        }
    }
}
