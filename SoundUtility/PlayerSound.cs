using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Logik.SoundUtility
{
    public class PlayerSound
    {
        public void PlaySound(bool user)
        {
            SoundPlayer sp = new SoundPlayer();

            //hrac
            if (user)
            {
                sp.Stream = Properties.Resources.LogikSoundFigure;
            }
            else
            {
                sp.Stream = Properties.Resources.LogikSoundEvaluated;
            }

            try
            {
                sp.Load();
                sp.Play();                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
