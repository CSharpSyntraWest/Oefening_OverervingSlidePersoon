
using System;
using System.Collections.Generic;

namespace SingleInheritance
{
    enum Geslacht
    {
        Man,
        Vrouw
    }
    class Persoon
    {
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public Geslacht Geslacht { get; set; }
        public Persoon(string naam,DateTime geboorteDatum, Geslacht geslacht)
        {
            Naam = naam;
            GeboorteDatum = geboorteDatum;
            Geslacht = geslacht;
        }

    }


    class Student : Persoon
    {
        public string Klas { get; set; }
        private List<Module> _ingeschrevenModules;
        public Student(string naam, string klas,DateTime geboorteDatum, Geslacht geslacht) : base(naam,geboorteDatum,geslacht)
        {
            Klas = klas;
            _ingeschrevenModules = new List<Module>();
        }
        public void SchrijfInVoorModule(Module module)
        {
            _ingeschrevenModules.Add(module);
        }
        public void SchrijfUitVoorModule(Module module)
        {
            _ingeschrevenModules.Remove(module);
        }
        public void PrintModules()
        {
            foreach (Module module in _ingeschrevenModules)
            {
                Console.WriteLine($"\t->module :{module.Naam} lestijden: {module.Lestijden}");
            }
        }
    }


    class Werknemer : Persoon
    {
        public string Bedrijf { get; set; }
        public decimal Loon { get; set; }
        public Werknemer(string naam, string bedrijf, decimal loon, DateTime geboorteDatum, Geslacht geslacht) : base(naam,geboorteDatum,geslacht)
        {
            Loon = loon;
            Bedrijf = bedrijf;
        }
        
    }
    class Docent : Werknemer
    {
        private List<Module> _modules;

        public Docent(string naam, string bedrijf, decimal loon, DateTime geboorteDatum, Geslacht geslacht) : base(naam,bedrijf,loon, geboorteDatum, geslacht)
        {
            _modules = new List<Module>();
        }
        public void VoegModuleToe(Module module)
        {
            _modules.Add(module);
        }
        public void VerwijderModule(Module module)
        {
            _modules.Remove(module);
        }

        public void PrintModules()
        {
            foreach (Module module in _modules)
            {
                Console.WriteLine($"\t->module :{module.Naam} lestijden: {module.Lestijden}");
            }
        }
    }



    class Module
    {
        public string Naam { get; set; }
        public int Lestijden { get; set; }

    }

    class Program
    {
        static void Main()
        {
            Persoon p1 = new Persoon("Jan",new DateTime(2005,10,12),Geslacht.Man);
            Print(p1);
            Module m1 = new Module() { Naam = "C# Programmeren 1", Lestijden = 42 };
            Module m2 = new Module() { Naam = "Java", Lestijden = 45 };
            Module m3 = new Module() { Naam = "Databanken", Lestijden = 35 };
            Werknemer w1 = new Werknemer("Piet", "KBC", 4800.58m, new DateTime(2000, 4, 1), Geslacht.Man);
            Print(w1);
            Docent d1 = new Docent("Joke", "Syntra-West", 2500.50m, new DateTime(2003, 9, 15), Geslacht.Vrouw);
            d1.VoegModuleToe(m1);
            d1.VoegModuleToe(m2);
            d1.VoegModuleToe(m3);

            Print(d1);
            Student s1 = new Student("Joris", "VDOC#1", new DateTime(2002, 5, 1), Geslacht.Man);
            s1.SchrijfInVoorModule(m1);
            s1.SchrijfInVoorModule(m2);
            s1.SchrijfInVoorModule(m3);
            s1.SchrijfUitVoorModule(m2);
            Print(s1);
            Console.ReadLine();
        }
        static void Print(Persoon persoon)
        {
            Console.Write($"Naam: {persoon.Naam} ");
            if (persoon is Werknemer)
            {
                Werknemer w = persoon as Werknemer;
                Console.Write($"Loon: {w.Loon} - Bedrijf: {w.Bedrijf}");
            }
            if (persoon is Docent)
            {
                Docent d = persoon as Docent;
                Console.WriteLine($"\nGeeft modules : ");
                d.PrintModules();
            }
            if (persoon is Student)
            {
                Student c = persoon as Student;
                Console.Write($"Klas: {c.Klas} ");
                Console.WriteLine($"\nvolgt modules : ");
                c.PrintModules();
            }
            Console.WriteLine();
        }
    }
}



