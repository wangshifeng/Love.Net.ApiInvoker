using System.Collections.Generic;
using System.IO;
using Host.ViewModels;
using Love.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Host.Controllers {
    [Route("api/[controller]")]
    public class SenderController : ControllerBase {
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        [HttpPost("[action]")]
        public void Push() {
            using (var stream = HttpContext.Request.Body) {
                using (var reader = new BinaryReader(stream)) {
                    // app Id.
                    var appId = reader.ReadString();

                    // data
                    var data = reader.ReadString();

                    var appMsg = JsonConvert.DeserializeObject<AppMessage>(data);
                    
                    // targets
                    var count = reader.ReadInt32();
                    if(count > 0) {
                        var list = new List<Target>();
                        for (int index = 0; index != count; ++index) {
                            var target = new Target {
                                ClientId = reader.ReadString(),
                                Alias = reader.ReadString()
                            };
                            list.Add(target);
                        }
                    }

                    // impls your push here.
                }
            }
        }

        [HttpPost("[action]")]
        public void Email([FromBody]SendEmailViewModel vm) {
            if(vm == null) {
                var invokeError = new InvokeError {
                    Code = nameof(Email),
                    Message = "The post body cannot deserialize to and email send model"
                };

                throw new Exception<InvokeError>(invokeError);
            }

            // impls send email here.
        }

        [HttpPost("[action]")]
        public void Sms([FromBody]SendSmsViewModel vm) {
            if (vm == null) {
                var invokeError = new InvokeError {
                    Code = nameof(Sms),
                    Message = "The post body cannot deserialize to and SMS send model"
                };

                throw new Exception<InvokeError>(invokeError);
            }

            if (string.IsNullOrEmpty(vm.Template)) {
                // send SMS without template
            }
            else {
                // send SMS with template
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
