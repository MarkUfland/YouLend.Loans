using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Ports.Adapters.Persistence.NHibernatePersistence

{
    /// <summary>
    /// This class is responsible for setting up the NHibernate session
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// A variable to hold the NHibernate configuration object 
        /// </summary>
        private static  NHibernate.Cfg.Configuration cfg;

        /// <summary>
        /// A variable to hold the NHibernate session factory object
        /// </summary>
        private static ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes static members of the <see cref="SessionHelper"/> class. It sets up session parameters 
        /// and configures the class mappings.
        /// </summary>
        static SessionHelper()
        {
            #region Using app config and mapping files

            //cfg = new Configuration();

            //cfg.Configure();
            //sessionFactory = cfg.BuildSessionFactory();

            #endregion

            #region Using code based configuration and mapping files

            //try
            //{
            //    cfg = new Configuration();

            //    var a = AppDomain.CurrentDomain.GetAssemblies();

            //    cfg.DataBaseIntegration(x =>
            //    {
            //        x.ConnectionString = @"Data Source=YLWIN81DEV1\SQLEXPRESS;Initial Catalog=YouLend.Loans;Integrated Security=True";
            //        x.Dialect<MsSql2012Dialect>();
            //        x.Driver<SqlClientDriver>();
            //        x.LogSqlInConsole = true;
            //    });

            //    sessionFactory = Fluently.Configure(cfg)
            //       .Mappings(
            //        //m => m.FluentMappings.AddFromAssemblyOf<LoansRepository>())
            //          m => m.FluentMappings.AddFromAssembly(mappingAssembly))
            //       .BuildSessionFactory();

            //    //cfg.AddAssembly(Assembly.GetExecutingAssembly());

            //    sessionFactory = cfg.BuildSessionFactory();
            //}
            //catch (Exception ex)
            //{
            //    int a = 1;
            //}

            #endregion

            #region Using Fluent NHibernate for mapping and the configuration class to configure from app settings

            try
            {
                cfg = new  NHibernate.Cfg.Configuration();

                cfg.Configure(); // read config default style

                var NHibernateMappingAssemblyName = ConfigurationManager.AppSettings["NHibernateMappingAssembly"];

                var NhibernateMappingAssembly = AppDomain
                                                    .CurrentDomain
                                                    .GetAssemblies()
                                                    .Where(a => a.FullName.Substring(0,a.FullName.IndexOf(',')) == NHibernateMappingAssemblyName)
                                                    .First();


                sessionFactory = Fluently.Configure(cfg)
                    .Mappings(
                       m => m.FluentMappings.AddFromAssembly(NhibernateMappingAssembly))
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                int a = 1;
            }
            #endregion

            #region Using Fluent NHibernate for mapping and configuration with a connection string for app settings

            ////sessionFactory = Fluently.Configure()
            ////                            .Database(MsSqlConfiguration.MsSql2008
            ////                                .ConnectionString(c => c
            ////                                    .FromAppSetting("connectionString"))
            ////                                .ShowSql())
            ////                            .Mappings(m => m
            ////                                .FluentMappings.AddFromAssemblyOf<DataContext>()
            ////                                    .ExportTo(@"C:\HibernateFiles"))
            ////                            .BuildSessionFactory();
            #endregion

            #region Using Fluent NHibernate for mapping and configuration with a database connection string factory providing the connection string

            ////sessionFactory = Fluently.Configure()
            ////                .Database(MsSqlConfiguration.MsSql2008
            ////                    .ConnectionString(ConnectionStringFactory.GetConnectionString(DBEntities.SOLID))
            ////                    .ShowSql())
            ////                .Mappings(m => m
            ////                    .FluentMappings.AddFromAssemblyOf<DataContext>()
            ////                         .ExportTo(@"C:\HibernateFiles"))
            ////                .BuildSessionFactory();
            #endregion
        }

        /// <summary>
        /// A public method that opens the NHibernate session
        /// </summary>
        /// <returns>An object that implements the ISession interface</returns>
        public static ISession GetNewSession()
        {
            
            return sessionFactory.OpenSession();
        }
    }

}
