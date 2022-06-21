using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T>
    {
        protected ApplicationDbContext _applicationDbContext;
        public BaseService(IServiceProvider serviceProvider)
        {
            _applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        }
    }
}
