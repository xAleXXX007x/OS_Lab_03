using System;

namespace OS_Lab_03
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryManager memoryManager = new MemoryManager(100, 10);

            memoryManager.AddPhysicalPage(new PhysicalPage("Page 1"));
            memoryManager.AddPhysicalPage(new PhysicalPage("Page 2"));
            memoryManager.AddPhysicalPage(new PhysicalPage("Page 3"));
            memoryManager.AddPhysicalPage(new PhysicalPage("Page 4"));
            memoryManager.AddPhysicalPage(new PhysicalPage("Page 5"));

            memoryManager.LoadVirtualPage(0, "Some New Data");
            memoryManager.LoadVirtualPage(1, "Read Only Data", true);

            memoryManager.UpdateVirtualPage(0, "Another New Data");
            memoryManager.UpdateVirtualPage(1, "New Read Only Data");

            memoryManager.LoadVirtualPage(2, "New Data 1");
            memoryManager.LoadVirtualPage(3, "New Data 2");

            memoryManager.PrintContains();

            memoryManager.SaveRAMToHDD();

            memoryManager.PrintContains();

            Console.ReadLine();
        }
    }
}
