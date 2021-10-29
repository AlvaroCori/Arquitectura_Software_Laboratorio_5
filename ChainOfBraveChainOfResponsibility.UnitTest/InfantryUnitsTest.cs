using System;
using Xunit;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.UnitTest
{
    public class InfantryUnitsTest
    {
        [Fact]
        public void TestRegimentAdvance()
        {
            InfantryUnits units = new InfantryUnits("4to regimiento", "defender");
            string request = units.Advance();
            string expected = "- 4to regimiento no puede avanzar tiene ordenes de defender.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestRegimentDefend()
        {
            InfantryUnits units = new InfantryUnits("4to regimiento", "avanzar");
            string request = units.Defend();
            string expected = "- 4to regimiento no puede defender tiene ordenes de avanzar.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestRegimentExecuteOrder()
        {
            InfantryUnits units = new InfantryUnits("4ta division", "avanzar");
            string request = units.ExecuteOrder("es invalida para","bailar");
            string expected = "La orden bailar es invalida para la unidad.";
            Assert.Equal(request, expected);
        }
        
        [Fact]
        public void TestAddSectionsToCompanyAndAdvance()
        {
            InfantryUnits units = new InfantryUnits("1ra compañia", "defender");
            AssaultInfantry section1 = new AssaultInfantry("1ra seccion","defender","busqueda");
            AssaultInfantry section2 = new AssaultInfantry("2da seccion","avanzar","busqueda");
            AssaultInfantry section3 = new AssaultInfantry("3ra seccion","avanzar","destruccion");
            units.Add(section1);
            units.Add(section2);
            units.Add(section3);
            string request = units.Advance();
            string expectedCompany = "- 1ra compañia no puede avanzar tiene ordenes de defender.\n";
            string expectedSection1 = "- 1ra seccion no puede avanzar tiene ordenes de defender.\n";
            string expectedSection2 = "+ 2da seccion de infanteria de asalto esta disponible para moverse.\n  La unidad puede ejecutar tacticas de busqueda.\n";
            string expectedSection3 = "+ 3ra seccion de infanteria de asalto esta disponible para moverse.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            Assert.Equal(request, expectedCompany+expectedSection1+expectedSection2+expectedSection3);
        }

        [Fact]
        public void TestAddSectionsToCompanyAndDefend()
        {
            InfantryUnits units = new InfantryUnits("1ra compañia", "avanzar");
            HeavyInfantry section1 = new HeavyInfantry("1ra seccion","avanzar","armas antitanque","baja");
            HeavyInfantry section2 = new HeavyInfantry("2da seccion","defender","armas incendiarias", "media");
            AssaultInfantry section3 = new AssaultInfantry("3ra seccion","defender","destruccion");
            units.Add(section1);
            units.Add(section2);
            units.Add(section3);
            string request = units.Defend();
            string expectedCompany = "- 1ra compañia no puede defender tiene ordenes de avanzar.\n";
            string expectedSection1 = "- 1ra seccion no puede defender tiene ordenes de avanzar.\n";
            string expectedSection2 = "+ 2da seccion de infanteria pesada esta equipando una defensa.\n  La unidad posee armas incendiarias.\n  La unidad posee media experiencia en armas pesadas.\n";
            string expectedSection3 = "+ 3ra seccion de infanteria de asalto esta preparada para defender.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            Assert.Equal(request, expectedCompany+expectedSection1+expectedSection2+expectedSection3);
        }
        [Fact]
        public void TestAddHierarchyMilitary()
        {
            InfantryUnits regiment = new InfantryUnits("1er regimiento", "defender");

            AssaultInfantry battalion = new AssaultInfantry("1er batallon","defender","sorpresa");

            AssaultInfantry company = new AssaultInfantry("1ra compañia","defender","sorpresa");

            AssaultInfantry section1 = new AssaultInfantry("1ra seccion","avanzar","destruccion");
            AssaultInfantry section2 = new AssaultInfantry("2da seccion","avanzar","busqueda");
            HeavyInfantry section3 = new HeavyInfantry("3ra seccion","defender","armas antitanque","media");
            HeavyInfantry section4 = new HeavyInfantry("4ta seccion","avanzar","armas incendiarias", "alta");
            
            company.Add(section1);
            company.Add(section2);
            company.Add(section3);
            company.Add(section4);

            battalion.Add(company);

            regiment.Add(battalion);

            string request = regiment.Advance();
            string expectedRegiment = "- 1er regimiento no puede avanzar tiene ordenes de defender.\n";
            string expectedBattalion = "- 1er batallon no puede avanzar tiene ordenes de defender.\n";
            string expectedCompany = "- 1ra compañia no puede avanzar tiene ordenes de defender.\n";
            string expectedSection1 = "+ 1ra seccion de infanteria de asalto esta disponible para moverse.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            string expectedSection2 = "+ 2da seccion de infanteria de asalto esta disponible para moverse.\n  La unidad puede ejecutar tacticas de busqueda.\n";
            string expectedSection3 = "- 3ra seccion no puede avanzar tiene ordenes de defender.\n";
            string expectedSection4 = "+ 4ta seccion de infanteria pesada puede moverse.\n  La unidad posee armas incendiarias.\n  La unidad posee alta experiencia en armas pesadas.\n";
            Assert.Equal(request, expectedRegiment+expectedBattalion+ expectedCompany+expectedSection1+expectedSection2+expectedSection3+expectedSection4);
        }
        [Fact]
        public void TestValidAddBattalion()
        {
            InfantryUnits regiment = new InfantryUnits("1er regimiento", "defender");
            AssaultInfantry battalion = new AssaultInfantry("1er batallon","defender","sorpresa");
            bool request = regiment.Add(battalion);
            Assert.True(request);
        }
        [Fact]
        public void TestInvalidAddSectionsForLimit()
        {
            InfantryUnits battalion = new InfantryUnits("1er batallon","defender");
            bool request = true;
            for (int sectionIndex = 0; sectionIndex<21; sectionIndex=sectionIndex+1)
            {
                request = request && battalion.Add(new AssaultInfantry($"{sectionIndex+1}° seccion","defender","busqueda"));
            }
            Assert.False(request);
        }
    }
}
