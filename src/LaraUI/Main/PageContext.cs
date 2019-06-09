﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using Microsoft.AspNetCore.Http;

namespace Integrative.Lara.Main
{
    sealed class PageContext : IPageContext
    {
        public HttpContext Http { get; }
        public Document Document { get; }

        readonly JSBridge _bridge;
        readonly Navigation _navigation;

        public PageContext(HttpContext http, Document document)
        {
            Http = http;
            Document = document;
            _navigation = new Navigation(this);
            _bridge = new JSBridge(document);
        }

        public IJSBridge JSBridge => _bridge;
        public INavigation Navigation => _navigation;

        public string RedirectLocation => _navigation.RedirectLocation;
    }
}