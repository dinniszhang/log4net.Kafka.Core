# log4net.Kafka.Core
log4net.Kafka.Core 的重写 参考沐雪

```<?xml version="1.0" encoding="utf-8" ?>
<log4net>
  <appender name="KafkaAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
	  <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
	  <username value="admin"/>
	  <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
	  <!-- 环境要求dotnet core 3+,使用说明：
		1.引用私服重构的log4net.Kafka.Core
		2.项目根目录建立log4net.config,和ca-cert.pem证书文件并调整属性为始终复制
		3.记录日志推荐使用log4net.Kafka.Core 1.1.4 log4net.Kafka.Core.KafkaLogHelper封装类
		4.*重要*,appid配置预设值 elk区分索引
	    5.eg:
		KafkaLogHelper.Info("这是一条普通日志");
		KafkaLogHelper.Debug("这是一条 Debug 日志");
		KafkaLogHelper.Warn("这是一条警告日志");
		KafkaLogHelper.Error("这是一条错误日志");
		try
		{
			throw new DivideByZeroException();
		}
		catch (Exception ex)
		{
			KafkaLogHelper.Error("这是一条异常日志", ex);
		}
	  -->
    </layout>
  </appender>
  <root>
    <level value="ALL"/>
    <appender-ref ref="KafkaAppender" />
  </root>
</log4net>```