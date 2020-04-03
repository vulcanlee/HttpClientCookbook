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

        [HttpGet("{name}/{age}")]
        public string ByRouting(string name, int age)
        {
            return $"HttpGet > ByRouting 得到的請求內容： Name={name} , Age={age}"; ;
        }

        [HttpGet]
        [Route("ByQueryString")]
        public string ByQueryString( string name, int age)
        {
            return $"HttpGet > ByQueryString 得到的請求內容： Name={name} , Age={age}"; ;
        }

        [HttpGet]
        [Route("ByForm")]
        public string ByForm([FromForm] string name, [FromForm]int age)
        {
            return $"HttpGet > ByForm 得到的請求內容： Name={name} , Age={age}"; ;
        }

        [HttpGet]
        [Route("ByFromFormComplex")]
        public string ByFromFormComplex([FromForm] HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpGet > ByFromFormComplex 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

        [HttpGet]
        [Route("ByFromBody")]
        public string ByFromBody([FromBody] HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpGet > ByFromBody 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }


        [HttpPost]
        [Route("ByPostJson")]
        public string ByPostJson(HttpEncodingRequestDto httpEncodingRequestDto)
        {
            return $"HttpPost > ByPostJson 得到的請求內容： Name={httpEncodingRequestDto.Name} , Age={httpEncodingRequestDto.Age}";
        }

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
