using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Lab_03
{
    class Memory
    {
        private int size;

        private List<Page> pages;

        private const int pageSize = 5;

        public Memory(int size)
        {
            this.size = size;
            pages = new List<Page>();
        }

        public void AddPage(Page page)
        {
            if (GetFreeSpace() < pageSize)
            {
                throw new Exception("Недостаточно места для добавления страницы.");
            }

            page.Id = pages.Count;
            pages.Add(page);
        }

        public Page GetPage(int index)
        {

            return index < GetSize() - 1 ? pages[index] : null;
        }

        public int GetSize()
        {
            return pages.Count * pageSize;
        }

        public int GetMaxSize()
        {
            return size;
        }

        public int GetFreeSpace()
        {
            return size - GetSize();
        }

        public Page ReplacePage(Page newPage)
        {
            Page LRUPage = null;

            foreach (Page page in pages)
            {
                if (LRUPage == null || (LRUPage as VirtualPage).LastUsed < (page as VirtualPage).LastUsed)
                {
                    LRUPage = page;
                }
            }

            pages.Remove(LRUPage);
            pages.Add(newPage);

            return LRUPage;
        }

        public List<Page> DumpPages()
        {
            List<Page> pages = new List<Page>();

            foreach(Page page in this.pages)
            {
                pages.Add(page);
            }

            this.pages.Clear();

            return pages;
        }

        public void PrintContains()
        {
            foreach (Page p in pages)
            {
                Console.WriteLine(p is PhysicalPage ? p : p as VirtualPage);
            }
        }
    }
}
