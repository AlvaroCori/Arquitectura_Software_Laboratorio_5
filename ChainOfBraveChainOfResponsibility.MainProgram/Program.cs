using System;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            InfantryUnits battalion1 = new InfantryUnits("1er batallon","defender");
            InfantryUnits company1 = new InfantryUnits("1ra compañia", "defender");
            InfantryUnits company2 = new InfantryUnits("2da compañia", "defender");
            InfantryUnits company3 = new InfantryUnits("3ra compañia", "defender");
            InfantryUnits company4 = new InfantryUnits("4ra compañia", "avanzar");

            AssaultInfantry section1 = new AssaultInfantry("1ra seccion", "defender","captura");
            AssaultInfantry section2 = new AssaultInfantry("2ra seccion", "avanzar","captura");
            AssaultInfantry section3 = new AssaultInfantry("3ra seccion", "defender","captura");
            HeavyInfantry section4 = new HeavyInfantry("4ra seccion", "defender","granadas incediarias","baja");
            HeavyInfantry section5 = new HeavyInfantry("5ra seccion", "avanzar","armas antitanque","media");

            AssaultInfantry section6 = new AssaultInfantry("6ra seccion", "defender","destruccion");
            AssaultInfantry section7 = new AssaultInfantry("7ra seccion", "avanzar","destruccion");

            AssaultInfantry section8 = new AssaultInfantry("8ta seccion", "avanzar","busqueda");
            AssaultInfantry section9 = new AssaultInfantry("9ma seccion", "defender","busqueda");
            HeavyInfantry section10 = new HeavyInfantry("10va seccion", "avanzar","armas antitanque","alta");

            company1.Add(section1);
            company1.Add(section2);
            company2.Add(section3);
            company2.Add(section4);
            company2.Add(section5);

            company3.Add(section6);
            company3.Add(section7);

            company4.Add(section8);
            company4.Add(section9);
            company4.Add(section10);

            battalion1.Add(company1);
            battalion1.Add(company2);
            
            Console.WriteLine(battalion1.Advance());
            Console.WriteLine(company3.Defend());
            Console.WriteLine(company4.Advance());
        }
    }
}
