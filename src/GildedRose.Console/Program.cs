using GildedRose.Business;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            ItemService itemService = new ItemService();

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~BEFORE~~~~~~~~~~~~~~~~~~~");
            WriteItemsPropertiesAndValues(itemService);

            itemService.UpdateQuality();

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~AFTER~~~~~~~~~~~~~~~~~~~");
            WriteItemsPropertiesAndValues(itemService);

            System.Console.ReadKey();

        }

        private static void WriteItemsPropertiesAndValues(ItemService itemService)
        {
            System.Console.WriteLine();

            foreach (var item in itemService.Items)
            {
                System.Console.WriteLine($"Name: {item.Name}\nQuality: {item.Quality}\nSellin: {item.SellIn}\n");
            }
        }
    }
}
