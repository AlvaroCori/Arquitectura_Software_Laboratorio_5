using System;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            InfantryUnits battalion1 = new InfantryUnits("1er batallon","detenerse");
            AssaultInfantry company1 = new AssaultInfantry("1ra compañia", "detenerse");
            AssaultInfantry company2 = new AssaultInfantry("2da compañia", "detenerse");

            AssaultInfantry section1 = new AssaultInfantry("1ra seccion", "detenerse");
            AssaultInfantry section2 = new AssaultInfantry("2ra seccion", "avanzar");
            AssaultInfantry section3 = new AssaultInfantry("3ra seccion", "detenerse");
             AssaultInfantry section4 = new AssaultInfantry("4ra seccion", "avanzar");
            //AssaultInfantry section1 = new AssaultInfantry("1ra seccion", "detenerse");
            ///AssaultInfantry company = new AssaultInfantry("1ra compañia", "detenerse");
            company1.Add(section1);
            company1.Add(section2);
            company2.Add(section3);
            company2.Add(section4);
            battalion1.Add(company1);
            battalion1.Add(company2);
            
            ///company.Add(section1);
            //company.Add(section2);
            Console.WriteLine(battalion1.Advance());
        }
    }
}
