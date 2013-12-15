using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators.Repositories
{
    /// <summary>
    /// Factory for resolveing repositories
    /// </summary>
    public class RepositoryDependencyFactory
    {

        #region Constants

        private const string FIRST_NAME_FLAG = "firstName";
        private const string LAST_NAME_FLAG = "lastName";

        #endregion


        #region Private fields

        private static IUnityContainer _container;

        #endregion


        #region Constructor

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static RepositoryDependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            _container = container;
            InjectDefaults();
        }

        #endregion


        #region Public Interfaces

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }


        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }


        /// <summary>
        /// Resolve IWordRepository type for first name.
        /// </summary>
        /// <returns></returns>
        public static IWordRepository ResolveFirstNameRepository()
        {
            IWordRepository ret = null;

            if (Container.IsRegistered(typeof(IWordRepository), FIRST_NAME_FLAG))
            {
                ret = Container.Resolve<IWordRepository>(FIRST_NAME_FLAG);
            }

            return ret;
        }


        /// <summary>
        /// Resolve IWordRepository type for last name.
        /// </summary>
        /// <returns></returns>
        public static IWordRepository ResolveLastNameRepository()
        {
            IWordRepository ret = null;

            if (Container.IsRegistered(typeof(IWordRepository), LAST_NAME_FLAG))
            {
                ret = Container.Resolve<IWordRepository>(LAST_NAME_FLAG);
            }

            return ret;
        }


        /// <summary>
        /// Register repository with first names.
        /// </summary>
        /// <param name="firstNameRepository">First names repository</param>
        public static void RegisterFirstNameRepository(IWordRepository firstNameRepository)
        {
            Container.RegisterInstance<IWordRepository>(FIRST_NAME_FLAG, firstNameRepository);
        }


        /// <summary>
        /// Register repository with last names.
        /// </summary>
        /// <param name="lastNameRepository">Last names repository</param>
        public static void RegisterLastNameRepository(IWordRepository lastNameRepository)
        {
            Container.RegisterInstance<IWordRepository>(LAST_NAME_FLAG, lastNameRepository);
        }

        #endregion


        #region Private fields

        private static void InjectDefaults()
        {
            if (!Container.IsRegistered(typeof(IWordRepository)))
            {
                Container.RegisterInstance<IWordRepository>(new WordRepository());
            }
            if (!Container.IsRegistered<IWordRepository>(FIRST_NAME_FLAG))
            {
                Container.RegisterInstance<IWordRepository>(FIRST_NAME_FLAG,
                    new WordRepository(Properties.Resources.english_first_name));
            }
            if (!Container.IsRegistered<IWordRepository>(LAST_NAME_FLAG))
            {
                Container.RegisterInstance<IWordRepository>(LAST_NAME_FLAG,
                    new WordRepository(Properties.Resources.english_last_name));
            }
            if (!Container.IsRegistered<IWordGenerator>())
            {
                Container.RegisterInstance<IWordGenerator>(new WordGenerator());
            }
            if (!Container.IsRegistered<ILoremIpsumRepository>())
            {
                Container.RegisterInstance<ILoremIpsumRepository>(new LoremIpsumRepository());
            }
        }

        #endregion
    }
}
