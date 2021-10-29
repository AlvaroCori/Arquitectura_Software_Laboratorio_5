using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class InfantryUnits : Units
    {
        private Units[] _childrens;
        private int _index;
        private int _size;
        protected string _actualOrder;
        public InfantryUnits(string group,string actualOrder):base(group)
        {
            _actualOrder = actualOrder;
            _childrens = new Units[20];
            _index = 0 ;
            _size = 20;
        }
        public InfantryUnits()
        {
            _childrens = new Units[20];
            _index = 0 ;
            _size = 20;
        }
        public override string Advance()
        {
            string request = "";
            for (int position = 0 ; position < _index; position = position + 1)
            {
                request = request + _childrens[position].Advance();
            }
            return base.Advance()+$" tiene ordenes de {_actualOrder}."+"\n"+request;
        }
        public override string Defend()
        {
            string request = "";
            for (int position = 0 ; position < _index; position = position + 1)
            {
                request = request + _childrens[position].Defend();
            }
            return base.Defend()+$" tiene ordenes de {_actualOrder}.\n"+request;
        }
        public bool Add(Units child)
        {
            if (_index < _size)
            {
                _childrens[_index] = child;
                _index = _index + 1;
            }
            return _index < _size;
        }
    }
}
