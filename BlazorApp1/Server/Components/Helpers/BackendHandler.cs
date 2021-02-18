//using System;
//using BlazorApp1.Client.Components.Services;
//using BlazorApp1.Shared.Components.Models.Account;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BlazorApp1.Server.Components.Helpers
//{
//    public class BackendHandler : HttpClientHandler
//    {
//        private ILocalStorageService _localStorageService;

//        public BackendHandler(ILocalStorageService localStorageService)
//        {
//            _localStorageService = localStorageService;
//        }

//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
//            CancellationToken cancellationToken)
//        {
//            // array in local storage for registered user
//            var userskey = "blazor-registration-login-example-users";
//            var users = await _localStorageService.GetItem<List<UserRecord>>(userskey) ?? new List<UserRecord>();
//            var method = request.Method;
//            var path = request.RequestUri.AbsolutePath;

//            return await handleRoute();

//            async Task<HttpResponseMessage> handleRoute()
//            {
//                if (path == "login" && method == HttpMethod.Post)
//                {
//                    return await MMLogin();
//                }

//                if (path == "notelist" && method == HttpMethod.Get)
//                {
//                    return await getNoteList();
//                }

//                return await base.SendAsync(request, cancellationToken);
//            }

//            // route function

//            async Task<HttpResponseMessage> MMLogin()
//            {
//                var bodyJson = await request.Content.ReadAsStringAsync();
//                var body = JsonSerializer.Deserialize<Login>(bodyJson);
//                var user = users.FirstOrDefault(x => x.Username == body.Username && x.Password == body.Password);

//                ServicesAccess s = new ServicesAccess();
//                var result = s.CallServiceRefLogin(user.Username, user.Password);

//                Console.WriteLine("Server/BackendHandler.cs: " + result);

//                return await ok(result);
//            }
//        }

//        // is not done
//        async Task<HttpResponseMessage> getNoteList()
//        {
//            return await ok();
//        }

//        // helper functions

//        async Task<HttpResponseMessage> ok(object body = null)
//        {
//            return await jsonResponse(HttpStatusCode.OK, body ?? new { });
//        }

//        async Task<HttpResponseMessage> error(string message)
//        {
//            return await jsonResponse(HttpStatusCode.BadRequest, new {message});
//        }

//        async Task<HttpResponseMessage> jsonResponse(HttpStatusCode statusCode, object content)
//        {
//            var response = new HttpResponseMessage
//            {
//                StatusCode = statusCode,
//                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
//            };

//            return response;
//        }

//        // class for user records stored by fake backend
//        public class UserRecord
//        {
//            public int Id { get; set; }
//            public string Username { get; set; }
//            public string Password { get; set; }
//        }
//    }
//}
