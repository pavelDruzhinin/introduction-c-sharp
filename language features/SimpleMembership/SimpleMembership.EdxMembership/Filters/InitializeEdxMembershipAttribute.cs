using System.Threading;
using SimpleMembership.EdxMembership.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SimpleMembership.EdxMembership.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeEdxMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Инициализаци нужных таблиц происходит только ОДИН раз при запуске приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                // Необходимо для того, чтобы исключить сообщения об ошибках, 
                // которые сгенерирует EF при несоответствии структуры БД и кода модели
                // SimpleMembership генерирует несколько внутренних таблиц, необходимых ему для работы
                // но ненужных в нашей модели
                Database.SetInitializer<EdxContext>(null);

                try
                {
                    using (var context = new EdxContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Создаем БД в обход EF Migration
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    // Указываем таблицу, где будут храниться данных о профайлах пользователей, и названия полей идентификатора и логина
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "EdxUserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        "The EdxMembership database could not be initialized. " +
                        "For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}