﻿/*
Copyright (c) 2019-2020 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using System;

namespace Integrative.Lara
{
    /// <summary>
    /// ColGroup element
    /// </summary>
    [Obsolete("Use HtmlColGroupElement instead")]
    public class ColGroup : HtmlColGroupElement
    {
    }

    /// <summary>
    /// The 'colgroup' HTML5 element
    /// </summary>
    /// <seealso cref="Element" />
    public class HtmlColGroupElement : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlColGroupElement"/> class.
        /// </summary>
        public HtmlColGroupElement() : base("colgroup")
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items"></param>
        public HtmlColGroupElement(params Node[] items) : base("colgroup", items)
        {
        }

        /// <summary>
        /// Gets or sets the 'span' HTML5 attribute.
        /// </summary>
        public int? Span
        {
            get => GetIntAttribute("span");
            set => SetIntAttribute("span", value);
        }
    }
}
