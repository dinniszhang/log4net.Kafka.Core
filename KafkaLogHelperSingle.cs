using log4net.Config;
using log4net.Repository;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace log4net.Kafka.Core
{
    /// <summary>
    ///  KafkaLogHelper类
    /// </summary>
    public static class KafkaLogHelperSingle
    {

        private static ILoggerRepository repository { get; set; }

        private static volatile ILog _log = null;
        /// <summary>
        /// 双检锁/双重校验锁（DCL，即 double-checked locking）
        /// </summary>
        /// <returns></returns>
        public static ILog log
        {
            get
            {
                if (_log == null)//提高效率
                {
                    lock (typeof(ILog))
                    {
                        if (_log == null) //防止多次创建单例对象
                        {
                            Configure();
                        }
                    }
                }
                return _log;
            }
        }
        /// <summary>
        /// log4net配置文件
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <param name="configFile"></param>
        public static void Configure(string repositoryName = "NETCoreRepository", string configFile = "log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _log = LogManager.GetLogger(repositoryName, "");
        }



        /// <summary>
        /// debug调试日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Debug(string message, Exception e = null)
        {
            log.Debug(GetCurrentMethodFullName() + " " + message, e);
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Info(string message, Exception e = null)
        {
            log.Info(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Warn(string message, Exception e = null)
        {
            log.Warn(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Error(string message, Exception e = null)
        {
            log.Error(GetCurrentMethodFullName() + " " + message, e);
        }
        /// <summary>
        /// 灾难日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">Exception异常</param>
        public static void Fatal(string message, Exception e = null)
        {
            log.Fatal(GetCurrentMethodFullName() + " " + message, e);
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
