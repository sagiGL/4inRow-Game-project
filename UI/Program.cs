using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Program
    {
        private static GameSetting m_UI;

        public static void Main()
        {
            m_UI = new GameSetting();
            m_UI.ShowDialog();
        }

        public static GameSetting UI
        {
            get { return m_UI; }
        }
    }
}
