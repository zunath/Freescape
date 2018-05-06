﻿using System.Collections.Generic;

namespace Freescape.Game.Server.ValueObject.Dialog
{
    public class DialogPage
    {
        public string Header { get; set; }
        public List<DialogResponse> Responses { get; set; }
        public object CustomData { get; set; }

        public DialogPage()
        {
            Responses = new List<DialogResponse>();
            Header = string.Empty;
        }

        public DialogPage(string header, params string[] responseOptions)
        {
            Responses = new List<DialogResponse>();
            Header = header;

            foreach (var response in responseOptions)
            {
                Responses.Add(new DialogResponse(response));
            }
        }

        public int NumberOfResponses => Responses.Count;
    }
}
