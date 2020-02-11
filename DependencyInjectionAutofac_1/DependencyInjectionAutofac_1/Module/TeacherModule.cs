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
    public class TeacherModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            base.Load(builder);
        }

    }
}
