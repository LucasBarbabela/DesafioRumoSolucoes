using Api.Enum;
using Api.Utility.Exception;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Utility
{
    class ResponseRet
    {
        public long Code;
        public string Message;
    }

    public class ApiResponse : ControllerBase
    {
        private ResponseRet response = null;
        public ApiResponse()
        {
            response = new ResponseRet();
        }

        public ActionResult<T> ResponseRet<T>(StatusCodeEnum statusCode, Object result = null)
        {
            switch (statusCode)
            {
                case StatusCodeEnum.Created:
                    return Created("Created", result);
                case StatusCodeEnum.NoContent:
                    return NoContent();
                default:
                    if (result == null) return Ok();
                    return Ok(result);
            }
        }
 
        public ActionResult<T> ResponseRet<T>(ApiException result)
        {
            response.Code = result.Code;
            response.Message = result.Message;

            switch (result.StatusCode)
            {
                case StatusCodeEnum.BadRequest:
                    return BadRequest(response);
                default:
                    return StatusCode(500, response);
            }
        }
        public ActionResult ResponseRetWithoutEnumerable(System.Exception result)
        {
            return ResponseRetWithoutEnumerable(new ApiException(result.Message));
        }
    }
}
