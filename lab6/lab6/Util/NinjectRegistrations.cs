using Ninject.Modules;
using Ninject.Web.Common;
using PhoneDictionaryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppContext = PhoneDictionaryLib.AppContext;

namespace lab3.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //новый каждое обращение (внедрение)
            //Bind<IPhoneDictionary>().To<FileRepository>();

            //новый на каждый поток
            //Bind<IPhoneDictionary>().To<FileRepository>().InThreadScope();

            //на каждый рекв
            //Bind<IPhoneDictionary>().To<FileRepository>().InRequestScope();


            Bind<IPhoneDictionary>().To<DataBaseRepository>().InSingletonScope().WithConstructorArgument("db", new AppContext());
        }
    }
}