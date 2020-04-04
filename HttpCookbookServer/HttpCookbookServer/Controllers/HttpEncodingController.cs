using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpCookbookServer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpCookbookServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpEncodingController : ControllerBase
    {
        // GET: api/HttpEncoding
        [HttpGet]
        public IEnumerable<HttpEncodingRequestDto> Get()
        {
            return new HttpEncodingRequestDto[] {
                new HttpEncodingRequestDto()
                {
                     Name = "王小明", Age=10
                }, new HttpEncodingRequestDto()
                {
                    Name = "張小美",Age=18
                }
            };
        }

        // https://localhost:5001/api/HttpEncoding/MyName/12
        [HttpGet("{name}/{age}")]
        public string ByRouting(string name, int age)
        {
            return $"HttpGet > ByRouting 得到的請求內容： Name={name} , Age={age}"; ;
        }

        // https://localhost:5001/api/HttpEncoding/MyName/?age=12
        [HttpGet("{name}")]
        [Route("ByRoutingAndQueryString")]
        public string ByRoutingAndQueryString(string name, int age)
        {
            return $"HttpGet > ByRoutingAndQueryString 得到的請求內容： Name={name} , Age={age}"; ;
        }

        // https://localhost:5001/api/HttpEncoding/ByQueryString/?name=MyName&age=12
        [HttpGet]
        [Route("ByQueryString")]
        public string ByQueryString(string name, int age)
        {
            return $"HttpGet > ByQueryString 得到的請求內容： Name={name} , Age={age}"; ;
        }

        // https://localhost:5001/api/HttpEncoding/ByForm/?name=MyName&age=12
        // 或者，使用 Form Data or Form Url 皆會觸發此方法
        //name:MyName
        //age:23
        [HttpGet]
        [Route("ByForm")]
        public string ByForm([FromForm] string name, [FromForm]int age)
        {
            return $"HttpGet > ByForm 得到的請求內容： Name={name} , Age={age}"; ;
        }

        // https://localhost:5001/api/HttpEncoding/ByFromFormComplex
        // 使用上面的 ByForm 的做法，都可以接收的到
        // QueryString , Form Data , Form Url 皆會觸發
        //name:MyName
        //age:23
        [HttpGet]
        [Route("ByFromFormComplex")]
        public string ByFromFormComplex([FromForm] HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpGet > ByFromFormComplex 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

        // https://localhost:5001/api/HttpEncoding/ByFromBody
        // 使用 Json 的編碼方式，就可以觸發
        //{
        //  "name": "MyName",
        //  "age": 33
        //}
        [HttpGet]
        [Route("ByFromBody")]
        public string ByFromBody([FromBody] HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpGet > ByFromBody 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

        // https://localhost:5001/api/HttpEncoding/ByPostJson
        // 記得，方法要改成 POST
        // 使用 Json 的編碼方式，就可以觸發
        //{
        //  "name": "MyName",
        //  "age": 33
        //}
        [HttpPost]
        [Route("ByPostJson")]
        public string ByPostJson(HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpPost > ByPostJson 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

        // https://localhost:5001/api/HttpEncoding/ByPostFromForm
        // 記得，方法要改成 POST
        // QueryString , Form Data , Form Url 皆會觸發
        //name:MyName
        //age:23
        [HttpPost]
        [Route("ByPostFromForm")]
        public string ByPostFromForm([FromForm] HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpPost > ByPostFromForm 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

        // PUT: api/HttpEncoding/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
