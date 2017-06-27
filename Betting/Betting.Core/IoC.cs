using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Betting.Core
{
    public sealed class IoC
    {
        private static IoC instance = null;

        private static readonly object padLock = new object();

        private readonly IUnityContainer container;

        private IoC()
        {
            var section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            container = new UnityContainer().LoadConfiguration(section);
        }

        public static IoC Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new IoC();
                    }
                }

                return instance;
            }
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
