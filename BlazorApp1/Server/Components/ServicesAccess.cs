using NoteWebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Note> CallServiceRefFindNotes(string username, string password, NoteSearchQuery noteSearchQuery)
        {
            // this is to access the backend through the service reference
            NoteWebServiceClient backend = 
                new NoteWebServiceClient();

            /* this is what it does when called */

            // login call to MMBackend to get verifiedSession
            var tempLoginResult = backend.LoginAsync(username, password).Result.LoginResult;

            // call to MMBackend to FindNotes
            var tempFindNote = backend.FindNotesAsync(tempLoginResult, noteSearchQuery).Result.FindNotesResult;

            return tempFindNote.ToList();
        }

        private void CallServiceRefCreateAudioNote()
        {

        }

    }
}
