
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using NMCT.Resto.CoreM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMCT.Resto.CoreM
{
    public class App : MvxApplication
    {

        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();


#pragma warning disable CS0618 // Type or member is obsolete
            //RegisterAppStart<TabInfoViewModel>();

            //RegisterAppStart<RestoTabsViewModel>();
#pragma warning restore CS0618 // Type or member is obsolete

            RegisterAppStart<RestosTableViewModel>();
        }

    }
}
