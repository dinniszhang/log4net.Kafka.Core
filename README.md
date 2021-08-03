# log4net.Kafka.Core
log4net.Kafka.Core 的重写,支持账号密码及pem证书

## 环境要求dotnet core 3+,使用说明：
### 1.生成并引用log4net.Kafka.Core,或搭建nuget私服
### 2.项目根目录建立log4net.config,和ca-cert.pem证书文件并调整属性为始终复制
### 3.记录日志推荐使用log4net.Kafka.Core.KafkaLogHelper封装类
### 4.*重要*,appid配置预设值 elk区分索引
### 5.eg:

```c#
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
```
6.log4netkafka升级1.1.7支持各级别日志单独配置。注意：由于初始化配置采用单例，故不支持热更新配置，更改配置需要重新启动应用。
```xml
<?xml version="1.0" encoding="utf-8" ?>
<log4net>
  <appender name="DebugAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
      <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
      <username value="admin"/>
      <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
    </layout>
  </appender>
  <appender name="InfoAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
      <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
      <username value="admin"/>
      <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
    </layout>
  </appender>
  <appender name="WarnAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
      <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
      <username value="admin"/>
      <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
    </layout>
  </appender>
  <appender name="ErrorAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
      <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
      <username value="admin"/>
      <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
    </layout>
  </appender>
  <appender name="FatalAppender" type="log4net.Kafka.Core.KafkaAppender, log4net.Kafka.Core">
    <KafkaSettings>
      <broker value="127.0.0.1:9092,127.0.0.1:9093" />
      <topic value="Log_test1" />
      <username value="admin"/>
      <password value="admin"/>
    </KafkaSettings>
    <layout type="log4net.Kafka.Core.KafkaLogLayout,log4net.Kafka.Core" >
      <appid value="cyqf-grpc-test" />
    </layout>
  </appender>
  <root>
    <level value="ALL"/>
  </root>
  <logger name="logDebug">
    <level value="Debug"/>
    <appender-ref ref="DebugAppender"/>
  </logger>
  <logger name="logInfo">
    <level value="Info"/>
    <appender-ref ref="InfoAppender"/>
  </logger>
  <logger name="logWarn">
    <level value="Warn"/>
    <appender-ref ref="WarnAppender"/>
  </logger>
  <logger name="logError">
    <level value="Error"/>
    <appender-ref ref="ErrorAppender"/>
  </logger>
  <logger name="logFatal">
    <level value="Fatal"/>
    <appender-ref ref="FatalAppender"/>
  </logger>
</log4net>
```
