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

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Google.Apis.Gmail.v1.UsersResource;
using System.Threading;
using TaxChatTAF;
using NUnit.Framework;

namespace TaxChatTAFSpecFlow.utils
{
    class GmailQuickstart
    {        
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

        public static string obtainLinkGmailConfirmation(string name, string lastname)
        {            
            UserCredential credential;
            string file = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_GMAIL_JSON);
            using (var stream =                
                new FileStream(file, FileMode.Open, FileAccess.Read))
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
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Boolean searchUnsuccessfull = true;
            Boolean emailFound = true;
            List<Message> mesageList = new List<Message>();
            DateTime date1 = DateTime.UtcNow;
            while (searchUnsuccessfull)
            {
                mesageList = ListMessages(service, USER_ID, "is:unread subject: Confirm your email to: " + name + " " + lastname);
                DateTime date2 = DateTime.UtcNow;
                TimeSpan timeDifference = date1.Subtract(date2);
                if (mesageList.Count > 0)
                {
                    searchUnsuccessfull = false;
                }else if ((timeDifference.TotalSeconds * -1) > 60)
                {
                    searchUnsuccessfull = false;
                    emailFound = false;
                }
            };
            Assert.AreEqual(true, emailFound);

            string answer = "";
            if (!searchUnsuccessfull)
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
                                }                                
                                answer = respuesta;
                                DeleteMessage(service, USER_ID, messagesiter.Id);
                                break;
                            }
                        }                       
                    }
                    catch (Exception)
                    {                        
                    }
                }                
            }
            return answer;
        }

        public static Message GetMessage(GmailService service, String userId, String messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception)
            {                
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
            catch (Exception)
            {                
            }            
        }

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
                catch (Exception)
                {                    
                }
            } while (!String.IsNullOrEmpty(request.PageToken));
            return result;
        }
        
        public static void DeleteMessage(GmailService service, String userId, String messageId)
        {            
            try
            {
                service.Users.Messages.Delete(userId, messageId).Execute();
            }
            catch (Exception)
            {                
            }
        }

        public static string obtainCodeRecoveryPassword(string name, string lastname)
        {
            UserCredential credential;
            string file = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_GMAIL_JSON);
            using (var stream =
                new FileStream(file, FileMode.Open, FileAccess.Read))
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
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Boolean searchUnsuccessfull = true;
            Boolean emailFound = true;
            List<Message> mesageList = new List<Message>();
            DateTime date1 = DateTime.UtcNow;
            while (searchUnsuccessfull)
            {
                mesageList = ListMessages(service, USER_ID, "is:unread subject: Reset your password to: " + name + " " + lastname);
                DateTime date2 = DateTime.UtcNow;
                TimeSpan timeDifference = date1.Subtract(date2);
                if (mesageList.Count > 0)
                {
                    searchUnsuccessfull = false;
                } else if ((timeDifference.TotalSeconds * -1) > 60)
                {
                    searchUnsuccessfull = false;
                    emailFound = false;
                }
            };
            Assert.AreEqual(true, emailFound);

            string answer = "";
            if (!searchUnsuccessfull)
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
                        string bodyMessage = mesageDetailt.Snippet;
                        string[] split1 = bodyMessage.Split(":");
                        string[] split2 = split1[1].Split(".");
                        string codeSend = split2[0];
                        answer = codeSend.Trim();
                        DeleteMessage(service, USER_ID, messagesiter.Id);                       
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return answer;
        }        
    }
}