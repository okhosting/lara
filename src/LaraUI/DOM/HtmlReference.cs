﻿/*
Copyright (c) 2019-2020 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using System.Collections.Generic;

namespace Integrative.Lara
{
    internal static class HtmlReference
    {
        private static readonly HashSet<string> SelfClosingTags;
        private static readonly HashSet<string> DoesRequireId;

        static HtmlReference()
        {
            SelfClosingTags = new HashSet<string>
            {
                "area",
                "base",
                "br",
                "col",
                "command",
                "embed",
                "hr",
                "img",
                "input",
                "keygen",
                "link",
                "meta",
                "param",
                "source",
                "track",
                "wbr"
            };
            DoesRequireId = new HashSet<string>
            {
                "input", "textarea", "select", "button", "option"
            };
        }

        public static bool IsSelfClosingTag(string tagNameLower)
            => SelfClosingTags.Contains(tagNameLower);

        public static bool RequiresId(string tagNameLower)
            => DoesRequireId.Contains(tagNameLower);
    }
}
