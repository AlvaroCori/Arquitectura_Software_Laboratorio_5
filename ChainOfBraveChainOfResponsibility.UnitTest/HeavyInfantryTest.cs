using System;
using Xunit;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.UnitTest
{
    public class HeavytInfantryTest
    {
        [Fact]
        public void TestBattalionAdvanceInvalid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "defender","bombas","alta");
            string request = unit.Advance();
            string expected = "- 2do batallon no puede avanzar tiene ordenes de defender.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionAdvanceValid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "avanzar","bombas","alta");
            string request = unit.Advance();
            string expected = "+ 2do batallon de infanteria pesada puede moverse.\n  La unidad posee bombas.\n  La unidad posee alta experiencia en armas pesadas.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionDefendInvalid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "avanzar","bombas","alta");
            string request = unit.Defend();
            string expected = "- 2do batallon no puede defender tiene ordenes de avanzar.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionDefendValid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "defender","bombas","alta");
            string request = unit.Defend();
            string expected = "+ 2do batallon de infanteria pesada esta equipando una defensa.\n  La unidad posee bombas.\n  La unidad posee alta experiencia en armas pesadas.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionExecuteOrderValid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "defender","bombas","alta");
            string request = unit.ExecuteOrder("esta equipando una defensa.", "defender");
            string expected = "+ 2do batallon de infanteria pesada esta equipando una defensa.\n  La unidad posee bombas.\n  La unidad posee alta experiencia en armas pesadas.\n";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestBattalionExecuteOrderInvalid()
        {
            HeavyInfantry unit = new HeavyInfantry("2do batallon", "avanzar","bombas","alta");
            string request = unit.ExecuteOrder("esta preparada para defender", "defender");
            string expected = "";
            Assert.Equal(request, expected);
        }
    }
}
