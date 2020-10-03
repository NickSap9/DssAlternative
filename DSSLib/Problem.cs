﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSSLib
{
    [Serializable]
    public class Problem : IOutput
    {
        //Общая информация о проблеме
        public string Name { get; set; }
        
        public List<Criteria> Criterias { get; set; }
        public List<Alternative> Alternatives { get; set; }
        public List<Case> Cases { get; set; }

        public Problem() : this("Неопознанная проблема")
        {
            Criterias = new List<Criteria>();
            Alternatives = new List<Alternative>();
            Cases = new List<Case>();
        }
        public Problem(string name)
        {
            Name = name;
        }



        //Загрузить решение
        public void AfterLoad()
        {
            foreach (Alternative alternative in Alternatives)
            {
                foreach (var priority in alternative.CriteriasPriorities)
                {
                    if (Criterias.Find(c => c.ID == priority.CriteriaID) is Criteria criteria)
                        priority.Key = criteria;
                    priority.Alternative = alternative;
                }
                foreach (var profit in alternative.CaseProfits)
                {
                    if (Cases.Find(c => c.ID == profit.CaseID) is Case caseC)
                        profit.Key = caseC;
                    profit.Alternative = alternative;
                }
            }
        }

        public List<Choice> GetDesizions()
        {
            return default;
        }
        public ChoiceAHP GetDesizionAHP()
        {
            if (ChoiceAHP.IsSolvable(this))
                return new ChoiceAHP(this);
            else
                return null;
        }
        public ChoiceCriterias GetDesizionCR()
        {
            if (ChoiceCriterias.IsSolvable(this))
                return new ChoiceCriterias(this);
            else
                return null;
        }

        //Вывод
        public void Output()
        {
            Console.WriteLine($"ПРОБЛЕМА: {Name}");
            Console.WriteLine(Print.GetPrintText("Критериев",$"{Criterias.Count}",false));
            foreach (var item in Criterias)
            {
                Console.WriteLine(Print.GetPrintText($"{item.Name}",$"база: {item.Importance}",true));
            }
            Console.WriteLine(Print.GetPrintText("Исходов",$"{Cases.Count}",false));
            foreach (var item in Cases)
            {
                Console.WriteLine(Print.GetPrintText($"{item.Name}",$"вер: {item.Chance}",true));
            }

            Console.WriteLine(Print.GetPrintText("Альтернативы",$"{Alternatives.Count}",false));
            foreach (var item in Alternatives)
            {
                Console.WriteLine(Print.GetPrintText($"{item.Name}",$"",true));
            }


            Console.WriteLine();

        }

    }
}