using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logik.Logic
{
    public class EvaluatedLogic
    {
        /// <summary>
        /// Evaluated line of user
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public int[] Evaluated(int[] input)
        {
            //output
            int[] output = new int[input.Count()];

            //go through the input data 
            for(int i = 0; i< input.Count(); i++)
            {
                //if base field figure contains input value
                if(MySettings.BaseFieldFigure.Contains(input[i]))
                {
                    //if is value from input is on the same position as base
                    if(MySettings.BaseFieldFigure[i] == input[i])
                    {
                        output[i] = 2; //black color
                    }
                    else //only cointais (not in position)
                    {
                        output[i] = 1; //white color
                    }
                }
                else //doesnt contains
                {
                    output[i] = -1; //dont exist
                }
            }

            //output array sort descending
            return output.OrderByDescending(x=> x).ToArray();

        }
    }
}
