using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkCommunicationMonitor.Models
{
    public class Global
    {
        public static int[] questionIDs = new int[3];
        public static Stack<string> questions = new Stack<string>();
        public static Stack<string> correctAnswers = new Stack<string>();
        
    }
}