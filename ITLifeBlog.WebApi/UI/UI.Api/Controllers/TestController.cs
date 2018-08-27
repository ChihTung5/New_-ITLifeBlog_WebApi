using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using UI.Api.Utility;

namespace UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 获取配置文件信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string JsonConfig()
        {
            var jsonStr = JsonConfigurationHelper.GetAppSettings<ConfigDTO>("ConnectionStrings");
            return jsonStr.ITLifeBlog;
        }

        /// <summary>
        /// 将日志写入数据库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic WriteLogToDb()
        {
            Logger logger = LogManager.GetLogger("DbLogger");
            LogEventInfo logEventInfo = new LogEventInfo();
            logEventInfo.Properties["Description"] = "我是自定义消息";
            logger.Info(logEventInfo);
            logger.Debug(logEventInfo);
            logger.Trace(logEventInfo);
            return Ok();
        }
    }
}