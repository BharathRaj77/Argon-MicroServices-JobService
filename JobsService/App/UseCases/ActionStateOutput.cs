using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCases
{
    public class ActionStateOutput
    {
        public int Id { get; }
        public string ActionType { get; }
        public int JobId { get; }
        public string JobStatus { get; }
        public DateTime ActionDateTime { get; }
        public string UserName { get; }
        public int EIN { get; }
        public string Notes { get; }
    }
}
