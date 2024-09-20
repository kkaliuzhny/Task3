using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class WinnerDeterminer
    {
        public static string GetWinner(int indexUserMove, int indexPcMove, string[,] arr, string res, string draw)
        {
            if(arr[indexUserMove,indexPcMove] ==  draw)
            {
                return "Draw";
            }
            else
            {
                return arr[indexUserMove,indexPcMove] == res ? "The computer wins" : "You win";
            }
           
        }
    }
}
