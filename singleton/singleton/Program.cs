using System;

namespace singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Získání instance Singletonu a volání metody
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();

            // Získání další instance Singletonu a volání metody
            Singleton anotherSingleton = Singleton.Instance;
            anotherSingleton.DoSomething();

            // Ověření že obě instance jsou shodné
            if (singleton == anotherSingleton)
            {
                Console.WriteLine("fachá, oboje jsou stejné");
            }

            // Zabránění uzavření konzole po spuštění programu
            Console.ReadLine();
        }
    }

    public class Singleton
    {
        // Statické pole pro uložení jediné instance třídy
        private static Singleton instance = null;

        // Zámek pro zajištění bezpečnosti vláken
        private static readonly object padlock = new object();

        // Soukromý konstruktor, aby nedošlo k vytvoření instance zvenčí
        private Singleton()
        {
        }

        // Veřejná statická vlastnost pro přístup k jediné instanci třídy
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        // Příklad metody v Singletonu
        public void DoSomething()
        {
            Console.WriteLine("Singleton metoda fachá");
        }
    }
}
