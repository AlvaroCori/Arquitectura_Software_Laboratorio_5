using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class Units:ITroopOrders
    {
        protected string _group;
        public Units(string group)
        {
            _group = group;
        }
        public Units()
        {
            _group = "unidad sin numero";
        }
        public virtual string Advance()
        {
            return $"- {_group} no puede avanzar";
        }
        public virtual string Defend()
        {
            return $"- {_group} no puede defender";
        }
        public virtual string ExecuteOrder(string message, string order)
        {
            return $"La orden {order} {message} la unidad.";
        }
    }
}
