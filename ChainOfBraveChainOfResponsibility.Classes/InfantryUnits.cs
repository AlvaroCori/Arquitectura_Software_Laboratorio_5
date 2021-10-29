using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class InfantryUnits : Units
    {
        private Units[] _childrens;
        private int _index;
        private int _size;
        public string _actualOrder;
        public InfantryUnits(string group,string actualOrder):base(group)
        {
            _childrens = new Units[20];
            _index = 0 ;
            _size = 20;
            _actualOrder = actualOrder;
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
            return base.Advance()+"\n"+request;
        }
        public bool Add(Units child)
        {
            if (_index < _size)
            {
                _childrens[_index] = child;
                _index = _index + 1;
                child._division = this;
            }
            return _index < _size;
        }
    }
}
