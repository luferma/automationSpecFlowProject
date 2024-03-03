// Copyright 2018 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START gmail_quickstart]
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Gmail.v1.UsersResource;
using System.Threading;

namespace GmailQuickstart
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        //static string[] Scopes = { GmailService.Scope.GmailReadonly };  
        static string[] Scopes = { GmailService.Scope.GmailLabels,
                                   GmailService.Scope.GmailModify,
                                   GmailService.Scope.GmailReadonly,
                                   GmailService.Scope.GmailCompose,
                                   GmailService.Scope.GmailInsert,                                  
                                   GmailService.Scope.GmailSend,
                                   GmailService.Scope.MailGoogleCom}; 
        static string ApplicationName = "Gmail API .NET Quickstart";

        const string USER_ID = "me";
        const string UNREAD_MARK = "UNREAD";
        const string HTTPS_SEARCH_STRING = "https";

        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            /*var mesage = GetMessage(service, "me", "1");
            Console.WriteLine(mesage.Messages.Count);
            if (mesage != null && mesage.Messages.Count > 0)
            {
                foreach (var messages in mesage.Messages)
                {
                    try
                    {
                        Console.WriteLine("{0}", messages.Payload.Body.Data);
                        Console.WriteLine("{0}", messages.Payload.Body.Data);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }*/

            /*var mesageList = ListMessages(service, "me");
            foreach (var part in mesageList)
            {
                try
                {
                    byte[] data = Convert.FromBase64String(part.Payload.Body.Data);
                    string decodedString = Encoding.UTF8.GetString(data);
                    Console.WriteLine(decodedString);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }*/
            //in:inbox is:unread subject:Confirm your email to:" + Christopher + " " + Jackson
            //var mesageList = ListMessages(service, USER_ID, "taxchat.support@ey.com: subject:Confirm your email: after:2020/02/10 ");
            var mesageList = ListMessages(service, USER_ID, "in:inbox is:unread subject:Confirm your email to: Luis Prueba");
            string answer = "";
            if (mesageList != null && mesageList.Count > 0)
            {
                foreach (var messagesiter in mesageList)
                {
                    try
                    {
                        List<string> labelsToRemove = new List<string>();
                        labelsToRemove.Add(UNREAD_MARK);
                        List<string> labelsToAdd = new List<string>();
                        var mesageDetailt = GetMessage(service, USER_ID, messagesiter.Id);
                        ModifyMessage(service, USER_ID, messagesiter.Id, labelsToAdd, labelsToRemove);
                        string bodyEmail="";
                        foreach (var messagePayIter in mesageDetailt.Payload.Parts)
                        {
                            if(messagePayIter.MimeType.Equals("text/plain"))
                            {
                                bodyEmail = messagePayIter.Body.Data;
                                byte[] dataBody = Convert.FromBase64String(bodyEmail);
                                string decodedString = Encoding.UTF8.GetString(dataBody);
                                string decodedStringReplaceBack= decodedString.Replace("\r", " ");
                                string decodedStringReplaceBack2 = decodedStringReplaceBack.Replace("\n", " ");
                                string[] words = decodedStringReplaceBack2.Split(' ');
                                string respuesta = "";
                                foreach (var word in words)
                                {
                                    bool b = word.Contains(HTTPS_SEARCH_STRING);
                                    if(b)
                                    {
                                        respuesta = word;
                                        break;
                                    }
                                    System.Console.WriteLine($"{word}");
                                }                                
                                answer = respuesta;
                                DeleteMessage(service, USER_ID, messagesiter.Id);
                                break;
                            }
                        }
                        
                        

                        /*var res = mesageDetailt.Payload.Body.Data.Replace("-", "+").Replace("_", "/");
                        byte[] bodyBytes = Convert.FromBase64String(res);
                        string val = Encoding.UTF8.GetString(bodyBytes);
                        Console.WriteLine("{0}", val);*/

                        /*byte[] data = Convert.FromBase64String(mesageDetailt.Payload.Body.Data);
                        string decodedString = Encoding.UTF8.GetString(data);
                        Console.WriteLine("{0}", decodedString);*/
                        /*Console.WriteLine("{0}", mesageDetailt.Snippet);*/
                        //Console.WriteLine("{0}", mesageDetailt.Raw);

                        //byte[] data2 = Convert.FromBase64String(mesageDetailt.Payload.Body.Data);
                        //string decodedString = Encoding.UTF8.GetString(data2);

                        //Console.WriteLine("{0}", decodedString);

                        /*Console.WriteLine("{0}", mesageDetailt.Payload.Body.Data);*/
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                System.Console.WriteLine("Link: " + answer);
            }

            /*var mesageList2 = ListMessages(service, "me", "from:taxchat.support@ey.com: is:unread");
            foreach (var mesageListPart in mesageList)
            {
                try
                {
                    byte[] data = Convert.FromBase64String(mesageListPart.Payload.Body.Data);
                    string decodedString = Encoding.UTF8.GetString(data);
                    Console.WriteLine(decodedString);
                    Console.WriteLine("{0}", mesageListPart.Payload.Body.Data);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }*/

            // Define parameters of request.
            /*UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // List labels.            
            IList<Label> labels = request.Execute().Labels;
            string userID = request.UserId;            
            Console.WriteLine("{0}", userID);

            Console.WriteLine("Labels:");
            if (labels != null && labels.Count > 0)
            {
                foreach (var labelItem in labels)
                {
                    Console.WriteLine("{0}, {1}, {2}", labelItem.Name, labelItem.MessagesUnread, labelItem.MessagesTotal);                    
                }
            }
            else
            {
                Console.WriteLine("No labels found.");
            }*/
            Console.Read();

            //from:taxchat.support@ey.com: is:unread 





        }

        public static Message GetMessage(GmailService service, String userId, String messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }

        public static void ModifyMessage(GmailService service, String userId,
                                    String messageId, List<String> labelsToAdd, List<String> labelsToRemove)
        {
            ModifyMessageRequest mods = new ModifyMessageRequest();
            mods.AddLabelIds = labelsToAdd;
            mods.RemoveLabelIds = labelsToRemove;

            try
            {
                service.Users.Messages.Modify(mods, userId, messageId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            
        }
        //service.Users.Messages.Modify(mods, userId, messageId).Execute();

        public static List<Message> ListMessages(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();                    
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return result;
        }

        public static Google.Apis.Gmail.v1.Data.Thread ModifyThread(GmailService service, String userId,
                            String threadId, List<String> labelsToAdd, List<String> labelsToRemove)
        {
            ModifyThreadRequest mods = new ModifyThreadRequest();
            mods.AddLabelIds = labelsToAdd;
            mods.RemoveLabelIds = labelsToRemove;

            try
            {
                return service.Users.Threads.Modify(mods, userId, threadId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }

        public static void DeleteMessage(GmailService service, String userId, String messageId)
        {            
            try
            {
                service.Users.Messages.Delete(userId, messageId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

        }

    }
}
// [END gmail_quickstart]
