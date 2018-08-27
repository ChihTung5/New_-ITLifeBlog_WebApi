using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

namespace UI.Api.Utility
{
    /// <summary>
    /// 公共方法自定义读取appsettings.json配置文件信息
    /// </summary>
    public class JsonConfigurationHelper
    {
        public static T GetAppSettings<T>(string key, string path = "appsettings.json") where T : class, new()
        {
            var currentClassDir = Directory.GetCurrentDirectory();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                .Add(new JsonConfigurationSource { Path = path, Optional = false, ReloadOnChange = true })
                .Build();
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }
    }
}
