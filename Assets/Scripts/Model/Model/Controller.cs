using Model.ModelObjects.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Controller
    {
        private Person YouveChangedBro;

        public Controller()
        {
            
        }

        public void setPerson(Person p)
        {
            this.YouveChangedBro = p;
            this.YouveChangedBro.Changed += new ChangedEventHandler(UpdateUI);
        }
        
        public void UpdateUI(object sender, EventArgs e)
        {
            Console.WriteLine("Model Changed");
            Console.WriteLine(sender.ToString());
            Console.WriteLine(  ((Person)sender).Info()  );
            Console.WriteLine(e.ToString());
        }
        
    }
}
