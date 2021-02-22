using LeaveRequest.Context;
using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace LeaveRequest.Repositories.Data
{
    public class ParameterRepository : GeneralRepository<Parameter, MyContext,string>
    {
        //public IConfiguration Configuration { get; }
        private readonly MyContext myContext;
        public ParameterRepository(MyContext myContext) : base(myContext)
        {
            //this.Configuration = configuration;
            this.myContext = myContext;
        }

        public Parameter getByName(string name)
        {
            //string connectStr = Configuration.GetConnectionString("MyConnection");
            var parameter = myContext.Parameters.Where(a => a.Name == name).FirstOrDefault();   
            return parameter;
        }
    }
}
