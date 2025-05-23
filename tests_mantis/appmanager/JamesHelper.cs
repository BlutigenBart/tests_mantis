﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace tests_mantis
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + "" + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public void Delete(AccountData account) 
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name + "" + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }
        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("varify " + account.Name + "" + account.Password);
            String s = telnet.Read();
            System.Console.Out.WriteLine(s);
            return ! s.Contains("does not exist");
        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            return telnet;
        }
    }
}
