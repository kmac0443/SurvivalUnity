using Model.ModelObjects.Items;
using Model.ModelObjects.Person;
using System;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Controller controller = new Controller();
            controller.setPerson(player);
            player.AddItem(new Item());

            Console.WriteLine("Done");
            string catchPhrase = Console.ReadLine();

        }
    }
}
