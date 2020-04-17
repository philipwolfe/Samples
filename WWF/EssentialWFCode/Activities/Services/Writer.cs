using System;
using System.Workflow.ComponentModel;
using System.ComponentModel;

namespace EssentialWF.Services {
    public abstract class WriterService {
        public abstract void Write(string s);
    }
    public class ConsoleWriter : WriterService {
        public override void Write(string s) {
            Console.WriteLine(s);
        }
    }
}