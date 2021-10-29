using System;
using Xunit;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.UnitTest
{
    public class AssaultInfantryTest
    {
        [Fact]
        public void TestBattalionAdvanceInvalid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "defender","destruccion");
            string request = unit.Advance();
            string expected = "- 1er batallon no puede avanzar tiene ordenes de defender.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionAdvanceValid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "avanzar","destruccion");
            string request = unit.Advance();
            string expected = "+ 1er batallon de infanteria de asalto esta disponible para moverse.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionDefendInvalid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "avanzar","destruccion");
            string request = unit.Defend();
            string expected = "- 1er batallon no puede defender tiene ordenes de avanzar.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionDefendValid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "defender","destruccion");
            string request = unit.Defend();
            string expected = "+ 1er batallon de infanteria de asalto esta preparada para defender.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionExecuteOrderValid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "defender","destruccion");
            string request = unit.ExecuteOrder("esta preparada para defender", "defender");
            string expected = "+ 1er batallon de infanteria de asalto esta preparada para defender.\n  La unidad puede ejecutar tacticas de destruccion.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionExecuteOrderInvalid()
        {
            AssaultInfantry unit = new AssaultInfantry("1er batallon", "avanzar","destruccion");
            string request = unit.ExecuteOrder("esta preparada para defender", "defender");
            string expected = "";
            Assert.Equal(request, expected);
        }
        
       
    }
}
