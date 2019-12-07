﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using Integrative.Lara.Main;
using Integrative.Lara.Tools;
using Microsoft.AspNetCore.Http;  
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Integrative.Lara.Middleware
{
    [DataContract]
    class EventParameters
    {
        [DataMember]
        public Guid DocumentId { get; set; }

        [DataMember]
        public string ElementId { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public long EventNumber { get; set; }

        [DataMember(IsRequired = false)]
        public ClientEventMessage Message { get; set; }

        public virtual IFormFileCollection Files { get; set; }

        public static bool TryParse(IQueryCollection query, out EventParameters parameters)
        {
            if (MiddlewareCommon.TryGetParameter(query, "doc", out var documentText)
                && MiddlewareCommon.TryGetParameter(query, "el", out var elementId)
                && MiddlewareCommon.TryGetParameter(query, "ev", out var eventName)
                && MiddlewareCommon.TryGetParameter(query, "seq", out var sequence)
                && long.TryParse(sequence, NumberStyles.Any, CultureInfo.InvariantCulture, out var eventNumber)
                && Guid.TryParseExact(documentText, GlobalConstants.GuidFormat, out var documentId))
            {
                parameters = new EventParameters
                {
                    DocumentId = documentId,
                    ElementId = elementId,
                    EventName = eventName,
                    EventNumber = eventNumber
                };
                return true;
            }
            else
            {
                parameters = default;
                return false;
            }
        }

        public async Task ReadAjaxMessage(HttpContext http)
        {
            if (!http.Request.HasFormContentType)
            {
                return;
            }
            var form = await http.Request.ReadFormAsync();  // TODO: cancellation token for shutdown
            if (form.TryGetValue(GlobalConstants.MessageKey, out var values))
            {
                Message = LaraTools.Deserialize<ClientEventMessage>(values);
            }
            Files = form.Files;
        }
    }

    [DataContract]
    class SocketEventParameters : EventParameters
    {
        [DataMember(IsRequired = false)]
        public FormFileCollection SocketFiles { get; set; }

        public override IFormFileCollection Files => SocketFiles;
    }
}