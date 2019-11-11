﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 11/2019
Author: Pablo Carbonell
*/

using Integrative.Lara;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace SampleProject.Other
{
    [LaraPage(Address)]
    class AutocompletePage : IPage, IAutocompleteProvider
    {
        public const string Address = "/autocomplete";

        readonly AutocompleteElement _auto = new AutocompleteElement();
        readonly Element _span = Element.Create("span");

        readonly string[] _colors = { "red", "green", "blue", "orange", "yellow" };

        public Task OnGet()
        {
            var builder = new LaraBuilder(LaraUI.Document.Body);
            builder.Push("div")
                .Push(_auto)
                .Pop()
            .Pop()
            .Push("div")
                .Push("button")
                    .InnerText("Read")
                    .On("click", () =>
                    {
                        _span.InnerText = _auto.Value;
                        return Task.CompletedTask;
                    })
                .Pop()
            .Pop()
            .Push("div")
                .AddNode(_span)
            .Pop();
            _auto.Start(new AutocompleteOptions
            {
                AutoFocus = true,
                MinLength = 0,
                Strict = true,
                Provider = this
            });
            return Task.CompletedTask;
        }

        public Task<AutocompleteResponse> GetAutocompleteList(string term)
        {
            var suggestions = new List<AutocompleteEntry>();
            var response = new AutocompleteResponse
            {
                Suggestions = suggestions
            };
            for (int index = 0; index < _colors.Length; index++)
            {
                var color = _colors[index];
                if (color.Contains(term))
                {
                    suggestions.Add(new AutocompleteEntry
                    {
                        Label = color,
                        Code = index.ToString(CultureInfo.InvariantCulture)
                    });
                }
            }
            return Task.FromResult(response);
        }
    }
}
