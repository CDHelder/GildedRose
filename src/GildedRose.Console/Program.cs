using GildedRose.Business;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            ItemService itemService = new ItemService();
            foreach (var item in itemService.Items)
            {
                System.Console.WriteLine($"Name: {item.Name}, Quality: {item.Quality}, Sellin: {item.SellIn}");
            }


            System.Console.ReadKey();

        }
    }
}
