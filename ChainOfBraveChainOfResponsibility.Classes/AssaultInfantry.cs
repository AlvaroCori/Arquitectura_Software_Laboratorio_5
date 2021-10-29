using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class AssaultInfantry : InfantryUnits
    {

        
        public AssaultInfantry(string group, string actualOrder):base(group, actualOrder)
        {
        }
        public override string Advance()
        {
            if (_actualOrder == "avanzar")
                return $"+ La infanteria de asalto de la {_group} puede moverse.\n";
            else
                return base.Advance();
        }

    }
}
