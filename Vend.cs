using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vending_Machine
{
    class Vend
    {
        double m_money;
        public Vend()
        {

        }
        public double Add(double amount)
        {
            return m_money += amount;
        }
        public void buy(double amount)
        {
            if(amount < m_money)
            {
                m_money -= amount;
            }
            else
            {
                
            }
        }
            public string getAmount()
            {
            return string.Format("{0:C2}", m_money);
            }
    }
}
