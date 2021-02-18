using BlazorApp1.Shared.Components.Models.Account;
using NoteWebServiceReference;
using System;
using System.IO;

namespace BlazorApp1.Server.Components.Audio
{
    public class CreateAudioNote
    {
        private LoginData model = new LoginData();

        private long UCreateAudioNote() // skal den være static??
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\", "Recording.m4a");
            long fileLength = new System.IO.FileInfo(filePath).Length;
            int size = (int)fileLength;
            var buffer = new byte[size];
            Console.WriteLine("Reading file.");
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                fs.Read(buffer, 0, size);
            }
            var wavBinary = buffer;

            Console.WriteLine("Calling Login.");
            var noteWebservice = new NoteWebServiceClient();
            var verifiedSession = noteWebservice.LoginAsync(model.Username, model.Password).Result.LoginResult;
            Console.WriteLine("Calling CreateAudioNote.");
            var audioNoteResult = noteWebservice.CreateAudioNoteAsync(verifiedSession, new AudioNote
            {
                Binary = new Binary
                {
                    BinaryData = wavBinary
                },

                Note = new Note
                {
                    Author = new User
                    {
                        Id = verifiedSession.LoginUserId,
                        UserNames = new[] { model.Username }
                    }
                }
            }, 200, 8, false);

            //if (audioNoteResult.Reason != NoteReason.None)
            //{
            //    Console.WriteLine($"CreateAudioNote failed {audioNoteResult.Reason}");
            //}
            //else
            //{
            //    Console.WriteLine("AudioNote created.");
            //}
            //return audioNoteResult.AudioNote.Note.Id;
            return 0;
        }
    }
}
