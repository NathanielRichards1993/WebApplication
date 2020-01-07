using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebApplication
{
    public class Server
    {
        //properties
        private int m_Number = -1; // default incorrect value
        private WebApplication.Alarm m_Alarm = null;

        //constructor
        public Server()
        {
            m_Alarm = new Alarm();
        }

        //getters & setters

        public string GetID()
        {
            if (m_Number > 0)
            {
                return m_Number.ToString();
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
                m_Number = value;
            }
            else
            {
                m_Number = -1;
            }
        }

        public void SetNewServerAndAlarmData(string insertValue)
        {
            //context check
            if (Regex.Match(insertValue, @"The alarm id from video server number \d{1,} is \d{1,}.").Success ||
                Regex.Match(insertValue, @"Alarm id \d{1,} has been received from video server number \d{1,}.").Success)
            {

                int GetSingleNumberFromMatch(Match _match)
                {
                    return int.Parse(Regex.Match(_match.ToString(), @"\d{1,}").ToString());
                }
                const string regexForServerId = @"server number \d{1,}";
                Match serverId = Regex.Match(insertValue, regexForServerId);


                const string regexForAlarmId = @"\b(is \d{1,}|id \d{1,})";
                Match alarmId = Regex.Match(insertValue, regexForAlarmId);

                SetID(GetSingleNumberFromMatch(serverId));
                GetAlarm().SetID(GetSingleNumberFromMatch(alarmId));
            }
            else
            {
                SetID(-1);
                GetAlarm().SetID(-1);
            }
        }

        public Alarm GetAlarm()
        {
            return m_Alarm;
        }
    }
}