using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class Units:ITroopOrders
    {
        public InfantryUnits _division;
        public string _group;
        public Units(string group)
        {
            _group = group;
        }
        public Units()
        {
            _division = null;
            _group = "no asignada";
        }
        public virtual string Advance()
        {
            return $"- {_group} tiene ordenes de detenerse.";
        }
    }
}
