using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class AssaultInfantry : InfantryUnits
    {
        private string _tactic;
        public AssaultInfantry(string group, string actualOrder,string tactic):base(group, actualOrder)
        {
            _actualOrder = actualOrder;
            _tactic = tactic;
        }
        public override string ExecuteOrder(string message, string order)
        {
            if (_actualOrder == order)
            {
                string request = $"+ {_group} de infanteria de asalto {message}.\n";
                request = $"{request}  La unidad puede ejecutar tacticas de {_tactic}.\n";
                return request;
            }
            else
                return "";
        }
        public override string Advance()
        {
            string request = ExecuteOrder("esta disponible para moverse", "avanzar");
            if (request != "")
                return request;
            else
                return base.Advance();
        }
        public override string Defend()
        {
            string request = ExecuteOrder("esta preparada para defender", "defender");
            if (request != "")
                return request;
            else
                return base.Defend();
        }

    }
}
