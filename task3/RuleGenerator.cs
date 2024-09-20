using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class RuleGenerator
    {
        private string[,] rulesArray;
        
        private string[] shiftToRight(string[] arr)
        {
           return new[]{ arr.Last() }.Concat( arr.Take(arr.Length - 1)  ).ToArray(); 
        }
        public string[,] RulesArray
        {
            get
            {
                return rulesArray;
            }
        }
      
      
        private string[] GenerateFirstRow(int n)
        {
            string[] RulesFirstRow = new string[n];
            RulesFirstRow[0] = "Draw";
            for (int i = 1; i < 1 + RulesFirstRow.Length / 2; i++)
            {
                RulesFirstRow[i] = "Win";
            }
            for (int i = 1 + RulesFirstRow.Length / 2; i < RulesFirstRow.Length; i++)
            {
                RulesFirstRow[i] = "Loose";
            }
            return RulesFirstRow;
        }
        public void generateRulesArray(int n)
        {

            rulesArray = new string[n, n];
            
            string[] rulesFirstRow = GenerateFirstRow(n);
            for (int i=0;i<n;i++) 
            { 
                for(int j=0;j<n;j++)
                {
                    rulesArray[i,j]= rulesFirstRow[j];
                }
                rulesFirstRow = shiftToRight(rulesFirstRow);
            }
        }
       
    }
}
