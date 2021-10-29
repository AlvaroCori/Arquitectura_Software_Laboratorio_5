using System;
using Xunit;
using ChainOfBraveChainOfResponsibility.Classes;
namespace ChainOfBraveChainOfResponsibility.UnitTest
{
    public class UnitsTest
    {
        [Fact]
        public void TestDivisionAdvance()
        {
            Units units = new Units("4ta division");
            string request = units.Advance();
            string expected = "- 4ta division no puede avanzar";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestDivisionDefend()
        {
            Units units = new Units("4ta division");
            string request = units.Defend();
            string expected = "- 4ta division no puede defender";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestDivisionExecuteOrder()
        {
            Units units = new Units("4ta division");
            string request = units.ExecuteOrder("es invalida para","bailar");
            string expected = "La orden bailar es invalida para la unidad.";
            Assert.Equal(request, expected);
        }
        [Fact]
        public void TestDivisionUnassigned()
        {
            Units units = new Units();
            string request = units.Defend();
            string expected = "- unidad sin numero no puede defender";
            Assert.Equal(request, expected);
        }
    }
}
