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
        public List<Note> CallServiceRefFindNotes(VerifiedSession verifiedSession, NoteSearchQuery noteSearchQuery)
        {
            // this is to access the backend through the service reference
            NoteWebServiceClient backend = 
                new NoteWebServiceClient();

            /* this is what it does when called */

            // login call to MMBackend to get verifiedSession
            //var tempLoginResult = backend.LoginAsync(username, password).Result.LoginResult;

            Console.WriteLine("ServiceAccess.cs veifiedSession?: " + verifiedSession);

            // call to MMBackend to FindNotes
            try
            {
                noteSearchQuery.AllowIntegrationNotes = true;
                noteSearchQuery.GroupIds = new long[1] {1};
                noteSearchQuery.GroupId = 1;
                noteSearchQuery.ColumnFilters = new NoteColumnFilter[1] {new NoteColumnFilter(){Column = "NoteType", Value = 1}};
                noteSearchQuery.IncludeSubgroups = true;
                noteSearchQuery.SortColumn = "Id";
                noteSearchQuery.SortAscending = true;
                noteSearchQuery.Take = 100;
                noteSearchQuery.StandaloneCanReadIntegration = true;
                noteSearchQuery.IntegrationCanReadStandalone = true;
                noteSearchQuery.IntegrationCode = IntegrationCode.Integration;
                noteSearchQuery.NoteSearchType = NoteSearchType.Normal;

                /*******************************************************************************/
                /* both noteSearchQuery and verifiedSession's specifiers have to be set manually
                 or the MMbackend vil not receive the data*/
                noteSearchQuery.IntegrationCodeSpecified = true;
                noteSearchQuery.AllowIntegrationNotesSpecified = true;
                noteSearchQuery.GroupIdSpecified = true;
                noteSearchQuery.IncludeSubgroupsSpecified = true;
                noteSearchQuery.IntegrationCanReadStandaloneSpecified = true;
                noteSearchQuery.IntegrationCanWriteStandaloneSpecified = true;
                noteSearchQuery.NoteSearchTypeSpecified = true;
                noteSearchQuery.ReturnSpeechNoteTextSpecified = true;
                noteSearchQuery.SkipSpecified = true;
                noteSearchQuery.SortAscendingSpecified = true;
                noteSearchQuery.StandaloneCanReadIntegrationSpecified = true;
                noteSearchQuery.StandaloneCanWriteIntegrationSpecified = true;
                noteSearchQuery.TakeSpecified = true;

                verifiedSession.IntegrationCodeSpecified = true;
                verifiedSession.LoginGroupIdSpecified = true;
                verifiedSession.LoginUserIdSpecified = true;
                verifiedSession.PasswordExpiredSpecified = true;
                verifiedSession.TimeSpecified = true;
                verifiedSession.ValidatedByProprietaryLoginSpecified = true;
                verifiedSession.VerifyKeySpecified = true;

                /*******************************************************************************/

                var tempFindNote = backend.FindNotesAsync(verifiedSession, noteSearchQuery);

                var result = tempFindNote.Result.FindNotesResult.ToList();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CallServiceRefCreateAudioNote()
        {

        }

    }
}
