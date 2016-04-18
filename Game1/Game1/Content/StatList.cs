using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    // The art for proper implemtation will be a frame for each stat number, and an up and down arrow to set each stat.
    class StatList
    {
        public int totalStats;
        public int strength;
        public int dexterity;
        public int constitution;

        public StatList()
        {
            totalStats = 3;
            strength = 1;
            dexterity = 1;
            constitution = 1;
        }

        /// <summary>
        /// Raises stat index and lowers total stat points. Returns true if there are stat points remaining.
        /// </summary>
        /// <returns></returns>
        public void upStr()
        {
            if (totalStats > 0)
            {
                strength++;
                totalStats--;
                
            }
            
        }

        /// <summary>
        /// Lowers stat index and raises total stat poitns. Returns true as long as points are removable from stat.
        /// </summary>
        /// <returns></returns>
        public void downStr()
        {
            if (strength > 1)
            {
                strength--;
                totalStats++;
                
            }
           
        }

        public void upDex()
        {
            if (totalStats > 0)
            {
                dexterity++;
                totalStats--;
                
            }
            
        }

        /// <summary>
        /// Lowers stat index and raises total stat poitns. Returns true as long as points are removable from stat.
        /// </summary>
        /// <returns></returns>
        public void downDex()
        {
            if (dexterity > 1)
            {
                dexterity--;
                totalStats++;
                
            }
           
        }

        public void upCon()
        {
            if (totalStats > 0)
            {
                constitution++;
                totalStats--;
               
            }
            
        }

        /// <summary>
        /// Lowers stat index and raises total stat poitns. Returns true as long as points are removable from stat.
        /// </summary>
        /// <returns></returns>
        public void downCon()
        {
            if (constitution > 1)
            {
                constitution--;
                totalStats++;
                
            }
            
        }

        


    }
}
