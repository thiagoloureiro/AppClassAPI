﻿using Service.Interface;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Requests;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessageController : ApiController
    {
        protected readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Retorna Lista de Mensagens
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("messagelist")]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(string), description: "Retorna Lista de Mensagens")]
        public IHttpActionResult GetMessageList()
        {
            var ret = _messageService.ListMessages();

            if (ret == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            return Json(ret);
        }
    }
}