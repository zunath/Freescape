﻿using System;
using System.Reflection;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject;
using Freescape.Game.Server.ValueObject.Dialog;
using NWN;

namespace Freescape.Game.Server.Conversation
{
    public abstract class ConversationBase
    {
        protected readonly INWScript _;
        private readonly IDialogService _dialog;

        protected ConversationBase(INWScript script, IDialogService dialog)
        {
            _ = script;
            _dialog = dialog;
        }

        protected NWPlayer GetPC()
        {
            return NWPlayer.Wrap(_.GetPCSpeaker());
        }

        protected NWObject GetDialogTarget()
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            return dialog.DialogTarget;
        }

        private CustomData GetDialogCustomData()
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            return dialog.CustomData;
        }

        protected T GetDialogCustomData<T>(string key)
        {
            CustomData data = GetDialogCustomData();
            if (!data.ContainsKey(key)) return default(T);
            return (T)GetDialogCustomData()[key];
        }

        protected void SetDialogCustomData(string key, dynamic value)
        {
            CustomData data = GetDialogCustomData();
            data[key] = value;
        }

        protected void ChangePage(string pageName)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            dialog.CurrentPageName = pageName;
            dialog.PageOffset = 0;
        }

        protected void SetPageHeader(string pageName, string header)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            page.Header = header;
        }

        protected DialogPage GetPageByName(string pageName)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            return dialog.GetPageByName(pageName);
        }

        protected DialogPage GetCurrentPage()
        {
            return GetPageByName(GetCurrentPageName());
        }

        protected string GetCurrentPageName()
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            return dialog.CurrentPageName;
        }

        protected DialogResponse GetResponseByID(string pageName, int responseID)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            return page.Responses[responseID - 1];
        }

        protected void SetResponseText(string pageName, int responseID, string responseText)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            page.Responses[responseID - 1].Text = responseText;
        }

        protected void SetResponseVisible(string pageName, int responseID, bool isVisible)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            page.Responses[responseID - 1].IsActive = isVisible;
        }

        protected void AddResponseToPage(string pageName, string text, bool isVisible = true,
            params Tuple<string, dynamic>[] customData)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            page.Responses.Add(new DialogResponse(text, isVisible, customData));
        }

        protected void ClearPageResponses(string pageName)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            DialogPage page = dialog.GetPageByName(pageName);
            page.Responses.Clear();
        }

        protected void SwitchConversation(string conversationName)
        {
            PlayerDialog dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            _dialog.LoadConversation(GetPC(), dialog.DialogTarget, conversationName, dialog.DialogNumber);
            dialog = _dialog.LoadPlayerDialog(GetPC().GlobalID);
            dialog.ResetPage();
            ChangePage(dialog.CurrentPageName);
            
            string @namespace = Assembly.GetExecutingAssembly().GetName().Name + ".Conversation." + dialog.ActiveDialogName;
            Type type = Type.GetType(@namespace);
            IConversation convo = App.ResolveByInterface<IConversation>(type);
            convo.Initialize();
            GetPC().SetLocalInt("DIALOG_SYSTEM_INITIALIZE_RAN", 1);
        }

        protected void EndConversation()
        {
            _dialog.EndConversation(GetPC());
        }
    }
}