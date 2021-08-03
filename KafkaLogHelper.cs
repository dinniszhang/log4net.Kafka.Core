using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace cyqf_api_diebiangaokao.Tools
{
    /// <summary>
    ///  KafkaLogHelper类
    /// </summary>
    public class KafkaLogHelper
    {

        private static ILoggerRepository repository { get; set; }

        private static volatile ILog _logDebug = null;
        private static volatile ILog _logInfo = null;
        private static volatile ILog _logWarn = null;
        private static volatile ILog _logError = null;
        private static volatile ILog _logFatal = null;
        /// <summary>
        /// 双检锁/双重校验锁（DCL，即 double-checked locking）
        /// </summary>
        /// <returns></returns>
        public static ILog logDebug
        {
            get
            {
                if (_logDebug == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_logDebug == null) //防止多次创建单例对象
                        {
                            ConfigureDebug();
                        }
                    }
                }
                return _logDebug;
            }
        }
        public static ILog logInfo
        {
            get
            {
                if (_logInfo == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_logInfo == null) //防止多次创建单例对象
                        {
                            ConfigureInfo();
                        }
                    }
                }
                return _logInfo;
            }
        }
        public static ILog logWarn
        {
            get
            {
                if (_logWarn == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_logWarn == null) //防止多次创建单例对象
                        {
                            ConfigureWarn();
                        }
                    }
                }
                return _logWarn;
            }
        }
        public static ILog logError
        {
            get
            {
                if (_logError == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_logError == null) //防止多次创建单例对象
                        {
                            ConfigureError();
                        }
                    }
                }
                return _logError;
            }
        }
        public static ILog logFatal
        {
            get
            {
                if (_logFatal == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_logFatal == null) //防止多次创建单例对象
                        {
                            ConfigureFatal();
                        }
                    }
                }
                return _logFatal;
            }
        }
        /// <summary>
        /// log4net配置文件
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <param name="configFile"></param>
        public static void ConfigureDebug(string repositoryName = "NETCoreRepository1", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _logDebug = LogManager.GetLogger(repositoryName, "logDebug");
        }
        public static void ConfigureInfo(string repositoryName = "NETCoreRepository2", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _logInfo = LogManager.GetLogger(repositoryName, "logInfo");
        }
        public static void ConfigureWarn(string repositoryName = "NETCoreRepository3", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _logWarn = LogManager.GetLogger(repositoryName, "logWarn");
        }
        public static void ConfigureError(string repositoryName = "NETCoreRepository4", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _logError = LogManager.GetLogger(repositoryName, "logError");
        }
        public static void ConfigureFatal(string repositoryName = "NETCoreRepository5", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _logFatal = LogManager.GetLogger(repositoryName, "logFatal");
        }



        /// <summary>
        /// debug调试日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Debug(string message, Exception e = null)
        {
            logDebug.Debug(GetCurrentMethodFullName() + " " + message, e);
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Info(string message, Exception e = null)
        {
            logInfo.Info(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Warn(string message, Exception e = null)
        {
            logWarn.Warn(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Error(string message, Exception e = null)
        {
            logError.Error(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 灾难日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Fatal(string message, Exception e = null)
        {
            logFatal.Fatal(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 获取路径及方法名
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentMethodFullName()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                StackTrace stackTrace = new StackTrace();
                return string.Concat(stackTrace.GetFrame(2).GetMethod().DeclaringType.ToString(), ".", stackTrace.GetFrame(2).GetMethod().Name);
            }
            catch
            {
                return "";
            }
        }
    }
}
