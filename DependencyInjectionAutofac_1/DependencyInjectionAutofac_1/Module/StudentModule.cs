using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DependencyInjectionAutofac_1.IRepository;
using DependencyInjectionAutofac_1.Repository;

namespace DependencyInjectionAutofac_1.Module
{
    class StudentModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            base.Load(builder);
           
        }
    }
}
