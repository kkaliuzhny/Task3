using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class TableGenerator
    {
        
        public static void ShowTable(string[] args, string[,] rules)
        {
            var table = new Table();
            table.AddColumn("[bold black on blue]PC\\USER[/]");
            for (int i = 0; i < args.Length; i++)
            {
                table.AddColumn($"[bold blue]{args[i]}[/]");
            }
            string[,] gameRules = new string[args.Length,args.Length+1];
            for(int i = 0; i < gameRules.GetLength(0); i++)
            {
                gameRules[i,0] = $"[bold blue]{args[i]}[/]";
            }

            for (int i = 0; i < gameRules.GetLength(0); i++)
            {
                for (int j = 1; j < gameRules.GetLength(1); j++)
                {
                    gameRules[i, j] = rules[i,j-1];
                }
            }


            for (int i = 0; i < args.Length; i++)
            {
                string[] row = new string[gameRules.GetLength(1)];
                for (int j = 0; j < gameRules.GetLength(1); j++)
                {
                    row[j] = gameRules[i, j];
                }
                table.AddRow(row);
            }
            AnsiConsole.Write(table);

        }

    }
}
