using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Operation : IOperation

{
    private DateTime executionDate { get; set; }
    private Enum type { get; set; }

    private string description { get; set; }

    public Operation()
    {

    }

    public Operation(OperationType.Type type, string desc)
    {
        this.executionDate = DateTime.Now;
        this.type = type;
        this.description = desc;
    }


        public void execute()
        {
        }
}
}
