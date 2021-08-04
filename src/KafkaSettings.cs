namespace log4net.Kafka.Core
{
    /// <summary>
    /// Kafka 参数配置
    /// </summary>
    public class KafkaSettings
    {
        /// <summary>
        /// Kafka Broker 地址，多个使用 "," 分隔
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// 日志主题名
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
