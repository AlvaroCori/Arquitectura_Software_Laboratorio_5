using System;

namespace ChainOfBraveChainOfResponsibility.Classes
{
    public class HeavyInfantry : InfantryUnits
    {
        private string _specialWeapons;
        private string _weaponExperience;
        
        public HeavyInfantry(string group, string actualOrder,string specialWeapons, string weaponExperience):base(group, actualOrder)
        {
            _specialWeapons = specialWeapons;
            _weaponExperience = weaponExperience;
        }
        public override string ExecuteOrder(string message, string order)
        {
            string request = "";
            if (_actualOrder == order)
            {
                    request = $"+ {_group} de infanteria pesada {message}\n";
                    request = request + $"  La unidad posee {_specialWeapons}.\n";
                    request = request + $"  La unidad posee {_weaponExperience} experiencia en armas pesadas.\n";
            }
            return request;
            
        }
        public override string Advance()
        {

            string request = ExecuteOrder("puede moverse.", "avanzar");
            if (request != "")
                return request;
            else
                return base.Advance();
        }
        public override string Defend()
        {
            string request = ExecuteOrder("esta equipando una defensa.", "defender");
            if (request != "")
                return request;
            else
                return base.Defend();
        }

    }
}
