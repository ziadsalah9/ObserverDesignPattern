
using System;

namespace ObserverDesignPattern
{



    public interface IObserver
    {
        void update (string message);
    }

    public class  Observalbe
    {

        
        List<IObserver> Observers = new List<IObserver>();

       private string _State;
        private int _Breadcount;


        public string State
        {
            get
            { return _State; }
            set
            {
                _State = value;
                NotifyObservers(" mess");
            }
        }


        public int BreadCount
        {
            get
            { return _Breadcount; }
            set
            {
                _Breadcount = value;
                NotifyObservers($" bread is increased {value}");
            }
        }






        public void Attach (IObserver Obsever)
        {

            Observers.Add(Obsever); 
        }

        public void Detach (IObserver Observer)
        {
            Observers.Remove(Observer);
        }


        public void NotifyObservers(string message )
        {

            foreach(var obs in Observers)
            {
             obs.update(message);

            }

        }
        public void StopProduction()
        {
            NotifyObservers($"انتهت عملية الإنتاج. الإجمالي: {BreadCount} أرغفة");
        }

    }



    public class showmessage : IObserver
    {
        public void update(string message)
        {

            Console.WriteLine($"Observer is notified with message {message}");
        }
    }



    internal class Program
    {

        static void Main (string[] args)
        {
            
            var bakery = new Observalbe();

            var sh = new showmessage();

            bakery.Attach(sh);
            bakery.BreadCount = 10;

            for (int i = 0; i < 5; i++)
            {

                bakery.BreadCount++;
            }


            Console.ReadKey();


        }

    }






}