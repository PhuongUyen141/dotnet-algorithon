using System;
using System.Threading.Tasks;
using algorithon_server.Models;
using algorithon_server.Utils.Jdoodle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompilerController : ControllerBase
    {
        [HttpPost]
        public JdoodleResponse Run(JdoodleRequest body)
        {
            if (body == null || body.Index == null || body.Lang == null || body.Program == null)
            {
                return new JdoodleResponse()
                {
                    Error = "Body invalid",
                    Data = null,
                    Message = "Error"
                };
            }
            var jdoodle = new JdoodleHandler();
            var result = jdoodle.PostRunRequest(body.Lang, body.Index, body.Program);

            return new JdoodleResponse()
            {
                Error = null,
                Data = result.Result,
                Message = "OK"
            };
        }
    }
}