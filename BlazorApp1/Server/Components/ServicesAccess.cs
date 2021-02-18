using NoteWebServiceReference;
using System;

namespace BlazorApp1.Server.Components
{
    public class ServicesAccess
    {
        // Service call to backend to login
        public VerifiedSession CallServiceRefLogin(string username, string password)
        {
            // this is to access the backend through the service reference
            NoteWebServiceClient backend =
                new NoteWebServiceClient();

            // this is what it does when called
            var tempLoginResult = backend.LoginAsync(username, password).Result.LoginResult;

            Console.WriteLine("Server/ServicesAccess.cs: " + tempLoginResult);

            return tempLoginResult;
        }

        // Service call to backend to make a AudioNote
        private void CallServiceRefCreateAudioNote(object sender, EventArgs e)
        {
            // this is to access the backend through the service reference
            MMBackendServiceReference2.AudioNoteResult audioNoteResult = 
                new MMBackendServiceReference2.AudioNoteResult();

            // this is what it does when called
            
        }


    }
}
