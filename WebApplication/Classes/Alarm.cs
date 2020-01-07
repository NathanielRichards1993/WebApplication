using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Alarm
    {
        //properties
        private int m_ID = -1;
        private Server m_RServer = null;
        //constructor
        public Alarm()
        {
        }

        //getters & setters
        public string GetID()
        {
            if (m_ID > 0)
            {
                return m_ID.ToString();
            }
            else
            {
                return "empty";
            } 
        }
        public void SetID(int value)
        {
            if (value > 0)
            {
                m_ID = value;
            }
            else
            {
                m_ID = -1;
            }
        }
    }
}
